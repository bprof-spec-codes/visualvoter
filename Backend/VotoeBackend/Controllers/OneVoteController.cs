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

        public OneVoteController(IOneVoteLogic logic)
        {
            this.oneVoteLogic = logic;
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
        public IActionResult CreateVote([FromBody] OneVote vote)
        {
            if (this.oneVoteLogic.CreateOneVote(vote)) return Ok();
            else return BadRequest();
        }

        [HttpPut("{oldId}")]
        public IActionResult UpdateVote(int oldId, [FromBody] OneVote vote)
        {
            if (this.oneVoteLogic.UpdateOneVote(oldId, vote)) return Ok();
            else return BadRequest();
        }
    }
}
