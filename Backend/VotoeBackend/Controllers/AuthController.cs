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
    [Route("{controller}")]
    public class AuthController : Controller
    {
        AuthLogic authLogic;

        public AuthController(AuthLogic authLogic)
        {
            this.authLogic = authLogic;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] IdentityUser model)
        {
            var loginObject = new Login() { Email = model.Email, Password = model.PasswordHash }; //TODO TEMP workaround
            string result = await authLogic.CreateUser_debug(loginObject);
            return Ok(new { UserName = result });
        }


        [HttpGet]
        public IEnumerable<IdentityUser> GetAllUsers()
        {
            return authLogic.GetAllUsers();
        }

        [HttpGet("{id}")]
        public IdentityUser GetUser(string id)
        {
            return this.authLogic.GetOneUser(id);
        }

        [HttpDelete("{id}")]
        public void DeleteUser(string id)
        {
            this.authLogic.DeleteUser(id);
        }
        [HttpPost]

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


    }
}
