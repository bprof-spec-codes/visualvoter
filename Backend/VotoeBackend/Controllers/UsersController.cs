using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Models;
using Logic;
using System;

namespace VotoeBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _config;

        private IUsersLogic usersLogic;

        private static readonly string[] Summaries = new[]
        {
            "Test3", "Test4"
        };

        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, IConfiguration config, IUsersLogic logic)
        {
            this._config = config;
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
    }
}
