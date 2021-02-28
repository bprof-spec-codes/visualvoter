using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Models;
using Logic;
using System;
using Microsoft.AspNetCore.Cors;

namespace VotoeBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUsersLogic usersLogic;
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, IUsersLogic logic)
        {
            this.usersLogic = logic;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Users> GetAllUser()
        {
            var output = this.usersLogic.GetAllUsers();
            foreach (var item in output)
            {
                item.UserPassword = null;
            }
            return output;
        }

        [HttpGet("{id}")]
        public Users GetUser(int id)
        {
            var output = this.usersLogic.GetOneUser(id);
            output.UserPassword = null;
            return output;        
        }

        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            this.usersLogic.DeleteUser(id);
        }

        [HttpPost]
        public void CreateUser([FromBody]Users user)
        {
            
            this.usersLogic.CreateUser(user);
        }

        [HttpPut("{oldId}")]
        public void UpdateUser(int oldId, [FromBody] Users user)
        {
            
            this.usersLogic.UpdateUser(oldId, user);
        }

        [Route("login")]
        [HttpPost]
        [DisableCors]
        public IActionResult Login([FromBody] Login login)
        {
            if (this.usersLogic.Login(login)) return Ok();
            return BadRequest();
        }
    }
}
