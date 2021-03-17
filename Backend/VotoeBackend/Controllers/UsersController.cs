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
            return this.usersLogic.GetAllUsers();
        }

        [HttpGet("{id}")]
        public Users GetUser(int id)
        {
            return this.usersLogic.GetOneUser(id);     
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
        public IActionResult Login([FromBody] Login login)
        {
            if (this.usersLogic.Login(login)) return Ok();
            return BadRequest();
        }

        [Route("usertype")]
        [HttpGet]
        public IEnumerable<UserType> GetAllUserTypes()
        {
            return this.usersLogic.GetAllUserTypes();
        }
    }
}
