using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using VotoeBackend.Controllers;
using Microsoft.Extensions.Logging;
using Models;

namespace VotOEApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OneVoteController : ControllerBase
    {
        private IOneVoteLogic oneVoteLogic;
        private readonly ILogger<UsersController> _logger;

        public OneVoteController(ILogger<UsersController> logger, IOneVoteLogic logic)
        {
            this.oneVoteLogic = logic;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<OneVote> GetAllOneVotes()
        {
            return this.oneVoteLogic.GetAllOneVote();
        }

        [HttpGet("{id}")]
        public OneVote GetOneVote(int id)
        {
            return this.oneVoteLogic.GetOneVote(id);
        }

        [HttpDelete("{id}")]
        public void DeleteVote(int id)
        {
            this.oneVoteLogic.DeleteOneVote(id);
        }

        [HttpPost]
        public void CreateVote([FromBody] OneVote vote)
        {
            this.oneVoteLogic.CreateOneVote(vote);
        }

        [HttpPut("{oldId}")]
        public IActionResult UpdateVote(int oldId, [FromBody] OneVote vote)
        {
            if (this.oneVoteLogic.UpdateOneVote(oldId, vote)) return Ok();
            else return BadRequest();
        }
    }
}
