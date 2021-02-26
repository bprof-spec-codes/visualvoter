using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Models;
using Logic;

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
        public IEnumerable<Users> Get()
        {
            return this.usersLogic.GetAllUsers();
        }
    }
}
