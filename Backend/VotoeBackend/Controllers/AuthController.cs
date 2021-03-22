using Logic.Class;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotOEApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        AuthLogic authLogic;

        public AuthController(AuthLogic authLogic)
        {
            this.authLogic = authLogic;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] Login model)
        {
            string result = await authLogic.CreateUser_debug(model);
            return Ok(new { UserName = result });
        }


        [HttpGet]
        public IEnumerable<IdentityUser> GetAllUsers()
        {
            return authLogic.GetAllUsers();
        }

        [HttpGet]
        [Route("getOne")]
        public IdentityUser GetUser([FromQuery]string id)
        {
            return this.authLogic.GetOneUser(id);
        }

        [HttpDelete("{id}")]
        public void DeleteUser(string id)
        {
            this.authLogic.DeleteUser(id);
        }

        [HttpPut("{oldId}")]
        public void UpdateUser(string oldId, [FromBody] IdentityUser user)
        {
            this.authLogic.UpdateUser(oldId, user);
        }

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

        [Route("allRoles")]
        [HttpGet]
        public IEnumerable<IdentityRole> getAllUserRoles()
        {
            return authLogic.getAllRoles();
        }
        [Route("userRoles")]
        [HttpPost]
        public IEnumerable<string> getAllRolesOfUser([FromBody] IdentityUser user)
        {
            return authLogic.getAllRolesOfUser(user);
        }

        [Route("assignRole")]
        [HttpPost]
        public ActionResult assignRole(RoleModel model)
        {
            authLogic.assignRolesToUser(model.User, model.Roles);
            return Ok();
        }
        [HttpGet]
        [Route("createRole")]
        public ActionResult createRole([FromQuery] string id)
        {
            authLogic.createRole(id);
            return Ok();
        }

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
    }
}
