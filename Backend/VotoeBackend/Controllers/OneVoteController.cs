using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Microsoft.Extensions.Logging;
using Models;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize(Roles = "Admin,Editor,Hallgató")]
        [HttpPost]
        public IActionResult SubmitVote([FromBody] OneVote vote)
        {
            var associatedVote = this.oneVoteLogic.getAssociatedVote(vote);
            if (this.User.IsInRole(associatedVote.RequiredRole))
            {
                this.oneVoteLogic.CreateOneVote(vote);
                return Ok();
            }
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
