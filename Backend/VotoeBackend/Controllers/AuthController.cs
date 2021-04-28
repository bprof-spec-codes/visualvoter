using Logic;
using Logic.Class;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VotOEApi.Controllers
{
    /// <summary>
    /// Controller dedicated to authentication + role management
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        AuthLogic authLogic;
        IRoleSwitchLogic roleSwitchLogic;

        /// <summary>
        /// Creates a new instance of AuthController
        /// </summary>
        /// <param name="authLogic">AuthLogic object (transient)</param>
        /// <param name="roleSwitchLogic">roleSwitchLogic object (transient)</param>
        public AuthController(AuthLogic authLogic, IRoleSwitchLogic roleSwitchLogic)
        {
            this.authLogic = authLogic;
            this.roleSwitchLogic = roleSwitchLogic;
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="model">Login model, containing the details of the user to be created.</param>
        /// <returns>Http200 if ok</returns>
        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] Login model)
        {
            string result = await authLogic.CreateUser_debug(model);
            return Ok(new { UserName = result });
        }

        /// <summary>
        /// List all the users
        /// </summary>
        /// <returns>A collection of all the users</returns>
        [HttpGet]
        public IEnumerable<IdentityUser> GetAllUsers()
        {
            return authLogic.GetAllUsers();
        }

        /// <summary>
        /// Get a single user
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <returns>A single user</returns>
        [HttpGet]
        [Route("getOne")]
        public IdentityUser GetUser([FromQuery]string id)
        {
            if (id.Contains('@'))
            {
                return this.authLogic.GetOneUser(null, id);
            }
            else
            {
               return this.authLogic.GetOneUser(id, null);
            }
        }

        /// <summary>
        /// Delete a single user
        /// </summary>
        /// <param name="id">Id of the user to be deleted</param>
        [HttpDelete("{id}")]
        public async void DeleteUser(string id)
        {
            await this.authLogic.DeleteUser(id);
        }

        /// <summary>
        /// Updates a single user
        /// </summary>
        /// <param name="oldId">The initial id of the user to be updated</param>
        /// <param name="user">IdentityUser model, containing the details of the user to be updated</param>
        [HttpPut("{oldId}")]
        public async void UpdateUser(string oldId, [FromBody] IdentityUser user)
        {
            await this.authLogic.UpdateUser(oldId, user);
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <remarks>Attempts to log in the user, and gives him a TokenModel if successful. </remarks>
        /// <param name="model">LoginModel, containing the details of the user logging in</param>
        /// <returns>A TokenModel if successful, BadRequest if not</returns>
        [HttpPut]
        public async Task<ActionResult> Login([FromBody] Login model)
        {
            try
            {
                return Ok(await authLogic.LoginUser(model));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        /// <summary>
        /// List all the roles
        /// </summary>
        /// <returns>A collection of all the roles</returns>
        [Route("allRoles")]
        [HttpGet]
        public IEnumerable<IdentityRole> getAllUserRoles()
        {
            return authLogic.GetAllRoles();
        }

        /// <summary>
        /// List the roles of a user
        /// </summary>
        /// <param name="user">User object, containing the details of the user in question</param>
        /// <returns>A collection of all the roles attached to the user</returns>
        [Route("userRoles")]
        [HttpPost]
        public IEnumerable<string> getAllRolesOfUser([FromBody] IdentityUser user)
        {
            return authLogic.GetAllRolesOfUser(user);
        }

        /// <summary>
        /// Assign one or more roles to a user.
        /// </summary>
        /// <param name="model">RoleModel, containing a usermodel, and a string list of all the roles to be added</param>
        /// <returns>Http200 if ok</returns>
        [Route("assignRole")] //TODO: Authenticate as admin!
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult assignRole(RoleModel model)
        {
            authLogic.AssignRolesToUser(model.User, model.Roles);
            return Ok();
        }

        /// <summary>
        /// Create a new role
        /// </summary>
        /// <param name="RoleName">The name of the new role</param>
        /// <returns>Http200 if successful</returns>
        [HttpGet]
        [Route("createRole")]
        public async Task<ActionResult> createRole([FromQuery] string RoleName)
        {
            await authLogic.CreateRole(RoleName);
            return Ok();
        }

        /// <summary>
        /// Auto-generate role
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Auto-generate a new role, used during vote creation. Each new vote has an associated "requiredRole" field, containing the role name generated here. Users in the posession of this role can participate in the vote.</remarks>
        /// <returns>The name of the new auto-generated role, or BadRequest if it failed</returns>
        [HttpPost]
        [Route("createRoleForVote")]
        public async Task<ActionResult> CreateRoleForVoteAsync([FromBody] List<string> id)
        {
            string generatedroleName = await this.authLogic.RoleCreationForNewVote(id);
            if (generatedroleName != null) return new JsonResult(generatedroleName);
            return BadRequest();
            
        }
        /// <summary>
        /// Debug RoleModel generation
        /// </summary>
        /// <returns>A RoleModel with some sample data</returns>
        [HttpGet]
        [Route("test")]
        public RoleModel makeTestRoleModelJson()
        {
            var output = new RoleModel();
            var users = authLogic.GetAllUsers();
            output.User = users.First();

            output.Roles = new List<string>() { "asd", "asdf" };
            return output;
        }

        /// <summary>
        /// Make a user Admin
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <returns>Http200 if successful</returns>
        [HttpGet]
        [Route("makeAdmin")]
        [Authorize(Roles = "Admin")]
        public ActionResult makeUserAdmin(string email)
        {
            var user = authLogic.GetOneUser(null, email);
            authLogic.AssignRolesToUser(user, new List<string> { "Admin" });

            return Ok();
        }

        /// <summary>
        /// Request to be put into another role
        /// </summary>
        /// <param name="roleName">The name of the role a user wants to be in.</param>
        /// <returns>Ok if the request was ok, badrequest if something else.</returns>
        [HttpGet("requestNewRole")]
        [Authorize]
        public  ActionResult RequestNewRole([FromQuery] string roleName)
        {
            if(this.roleSwitchLogic.RequestNewRole(roleName, this.User.FindFirstValue(ClaimTypes.NameIdentifier))) return Ok();
            return BadRequest();
        }

        /// <summary>
        /// Endoint made for admins to accept or decline role switch requests made by the users.
        /// </summary>
        /// <param name="roleSwitchID">The unique id of the request</param>
        /// <param name="choice">0 for yes, 1 for no</param>
        /// <returns>Ok if the request was ok, badrequest if something else.</returns>
        [HttpPost]
        [Route("requestNewRole")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> RequestNewRoleAsync([FromQuery] int roleSwitchID, [FromQuery] int choice)
        {
            if (choice == 1){ this.roleSwitchLogic.Delete(roleSwitchID); return Ok(); }
            if (choice == 0) {
                var roleSwitch = this.roleSwitchLogic.GetOne(roleSwitchID);
                await this.authLogic.SwitchRoleOfUser(roleSwitch.UserName, roleSwitch.RoleName);
                this.roleSwitchLogic.Delete(roleSwitchID);
                return Ok(); 
            }
            return BadRequest();
        }

        /// <summary>
        /// Gets all the requests made by the users.
        /// </summary>
        /// <returns>Collection of roleSwitch objects.</returns>
        [HttpGet("roleRequests")]
        [Authorize(Roles = "Admin")]
        public IEnumerable<RoleSwitch> GetAllRoleSwitchRequests()
        {
            return this.roleSwitchLogic.GetAllRoleSwitchRequests();
        }
    }
}
