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
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Logic.Interface;
using Microsoft.AspNetCore.Identity;

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

        //[Authorize]
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

        [Authorize(Roles = "Admin,Szerkesző")]
        [HttpPost]
        public ActionResult CreateVote([FromBody] AllVotes vote)
        {
            this.allVotesLogic.CreateVote(vote);
            return Ok();
        }

        [HttpPut("{oldId}")]
        public void UpdateVote(int oldId, [FromBody] AllVotes vote)
        {
            this.allVotesLogic.UpdateVote(oldId, vote);
        }


        // [Route("create")]
        // [HttpPost]
        // public ActionResult CreateNewVote([FromBody] AllVotes thisVote)
        //{
        //var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //if (this.User.IsInRole(voteCreation.RequiredRole))
        //{
        //    this.allVotesLogic.CreateVote(voteCreation);
        //    return Ok();
        //}
        //return Unauthorized();
        // this.allVotesLogic.CreateVote(thisVote);
        //return Ok();
        //}

        [Route("active")]
        [HttpGet]
        public IEnumerable<AllVotes> GetAllActiveVotes()
        {

            return this.allVotesLogic.GetAllActiveVotes();
        }

        [Authorize]
        [Route("usersVotes")]
        [HttpGet]
        public List<AllVotes> getAllUserAccessibleVotes()
        {
            var roles = ((ClaimsIdentity)User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value).ToList();

            //var userIdentity = (ClaimsIdentity)User.Identity;
            //var claims = userIdentity.Claims;
            //var roleClaimType = userIdentity.RoleClaimType;
            //var roles = claims.Where(c => c.Type == ClaimTypes.Role).ToList();

            return allVotesLogic.getAllAvaliableVotes(roles);
        }
    }
}
