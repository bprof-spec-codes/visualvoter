using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Logic;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace VotOEApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AllVotesController : ControllerBase
    {
        private IAllVotesLogic allVotesLogic;

        public AllVotesController(IAllVotesLogic logic)
        {
            this.allVotesLogic = logic;
        }

        [HttpGet]
        public IEnumerable<AllVotes> GetAllVotes()
        {
            return this.allVotesLogic.GetAllVotes();
        }

        [HttpGet("{id}")]
        public AllVotes GetOneVote(int id)
        {
            return this.allVotesLogic.GetOneVote(id);
        }

        [HttpDelete("{id}")]
        public void DeleteVote(int id)
        {
            this.allVotesLogic.DeleteVote(id);
        }

        [HttpPost]
        public void CreateVote([FromBody] AllVotes vote)
        {
            this.allVotesLogic.CreateVote(vote);
        }

        [HttpPut("{oldId}")]
        public void UpdateVote(int oldId, [FromBody] AllVotes vote)
        {
            this.allVotesLogic.UpdateVote(oldId, vote);
        }

        [Route("create")]
        [HttpPost]
        public void CreateNewVote([FromBody] VoteCreation voteCreation)
        {
            
            this.allVotesLogic.CreateNewVote(voteCreation);
        }

        [Route("active")]
        [HttpGet]
        public IEnumerable<AllVotes> GetAllActiveVotes()
        {
            return this.allVotesLogic.GetAllActiveVotes();
        }
    }
}
