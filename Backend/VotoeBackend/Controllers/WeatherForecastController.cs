using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace VotoeBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IConfiguration _config;

        private static readonly string[] Summaries = new[]
        {
            "Test3", "Test4"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return Data.VotoeDbContext.Test(_config["DBPassword"]).ToList();
        }
    }
}
