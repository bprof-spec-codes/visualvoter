using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Logic;
using VotoeBackend.Controllers;
using Microsoft.Extensions.Logging;

namespace VotOEApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AllVotesController : ControllerBase
    {
        private IAllVotesLogic allVotesLogic;
        private readonly ILogger<UsersController> _logger;

        public AllVotesController(ILogger<UsersController> logger, IAllVotesLogic logic)
        {
            this.allVotesLogic = logic;
            _logger = logger;
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
        public void DeleteUser(int id)
        {
            this.allVotesLogic.DeleteVote(id);
        }

        [HttpPost]
        public void CreateUser([FromBody] AllVotes vote)
        {
            this.allVotesLogic.CreateVote(vote);
        }

        [HttpPut("{oldId}")]
        public void UpdateUser(int oldId, [FromBody] AllVotes vote)
        {
            this.allVotesLogic.UpdateVote(oldId, vote);
        }

        [Route("create")]
        [HttpPost]
        public AllVotes CreateNewVote([FromBody] VoteCreation voteCreation)
        {
            return voteCreation.NewVote;
        }
    }
}
