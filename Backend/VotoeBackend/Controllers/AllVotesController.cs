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
    /// <summary>
    /// Controller for managing the votes
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    
    public class AllVotesController : ControllerBase
    {
        private IAllVotesLogic allVotesLogic;
        /// <summary>
        /// Creates a new instance of the AllVotes Controller
        /// </summary>
        /// <param name="logic">AllVotes logic object (transient)</param>
        public AllVotesController(IAllVotesLogic logic)
        {
            this.allVotesLogic = logic;
        }

        /// <summary>
        /// List all voting events
        /// </summary>
        /// <returns>A collection of all the votes</returns>
        /// <remarks>Lists all the past and present votes</remarks>
        //[Authorize]
        [HttpGet]
        public IEnumerable<AllVotes> GetAllVotes()
        {
            return this.allVotesLogic.GetAllVotes();
        }

        /// <summary>
        /// Gets a single AllVotes
        /// </summary>
        /// <param name="id">The ID of the AllVotes in question</param>
        /// <remarks>Returns a single AllVotes, specified by it's ID</remarks>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public AllVotes GetOneVote(int id)
        {
            return this.allVotesLogic.GetOneVote(id);
        }

        /// <summary>
        /// Deletes a single voting event
        /// </summary>
        /// <param name="id">The ID of the AllVotes to be deleted</param>
        [HttpDelete("{id}")]
        public void DeleteVote(int id)
        {
            this.allVotesLogic.DeleteVote(id);
        }

        /// <summary>
        /// Creates a new voting event (AllVotes)
        /// </summary>
        /// <param name="vote">AllVotes object, containing the details of the vote to be created</param>
        /// <returns>Http200 if ok</returns>
        [Authorize(Roles = "Admin,Editor")]
        [HttpPost]
        public ActionResult CreateVote([FromBody] AllVotes vote)
        {
            this.allVotesLogic.CreateVote(vote);
            return Ok();
        }

        /// <summary>
        /// Updates a single voting event
        /// </summary>
        /// <param name="oldId">The original id of the vote to be updated</param>
        /// <param name="vote">AllVotes object, containing the details of the vote to be updated</param>
        [HttpPut("{oldId}")]
        public void UpdateVote(int oldId, [FromBody] AllVotes vote)
        {
            this.allVotesLogic.UpdateVote(oldId, vote);
        }


        //[Route("create")]
        //[HttpPost]
        //public ActionResult CreateNewVote([FromBody] AllVotes thisVote)
        //{
        //    //var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //    if (this.User.IsInRole(voteCreation.RequiredRole))
        //    {
        //        this.allVotesLogic.CreateVote(voteCreation);
        //        return Ok();
        //    }
        //    return Unauthorized();
        //    this.allVotesLogic.CreateVote(thisVote);
        //    return Ok();
        //}

        /// <summary>
        /// Returns all the active votes
        /// </summary>
        /// <returns>A collection of every active vote</returns>
        [Route("active")]
        [HttpGet]
        public IEnumerable<AllVotes> GetAllActiveVotes()
        {

            return this.allVotesLogic.GetAllActiveVotes();
        }

        /// <summary>
        /// Lists all votes avaliable to the logged in user
        /// </summary>
        /// <returns>A collection of the voting events that are avaliable to the currently authenticated user</returns>
        [Authorize]
        [Route("usersVotes")]
        [HttpGet]
        public List<AllVotes> GetAllUserAccessibleVotes()
        {
            var roles = ((ClaimsIdentity)User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value).ToList();

            //var userIdentity = (ClaimsIdentity)User.Identity;
            //var claims = userIdentity.Claims;
            //var roleClaimType = userIdentity.RoleClaimType;
            //var roles = claims.Where(c => c.Type == ClaimTypes.Role).ToList();

            return allVotesLogic.GetAllAvaliableVotes(roles);
        }

        /// <summary>
        /// Marks a vote as closed
        /// </summary>
        /// <param name="id">The id of the vote to be closed</param>
        /// <returns>HTTP200 if all is good, 400 if not.</returns>
        [Authorize(Roles = "Admin,Editor")]
        [HttpGet("close/{id}")]
        public IActionResult CloseAVote(int id)
        {
            if (this.allVotesLogic.CloseAVote(id)) return Ok();
            return BadRequest();
        }

        /// <summary>
        /// Maks a vote as finished
        /// </summary>
        /// <param name="id">The id of the vote to be marked</param>
        /// <returns>HTTP200 if all is good, 400 if not.</returns>
        [Authorize(Roles = "Admin,Editor")]
        [HttpGet("finish/{id}")]
        public IActionResult FinishAVote(int id)
        {
            bool winStatus = false;
            winStatus = allVotesLogic.IsVoteWon(id);
            if (this.allVotesLogic.FinishAVote(id)) new JsonResult(winStatus);
            return BadRequest();
        }

        /// <summary>
        /// Gets all the voting events in the specified group
        /// </summary>
        /// <param name="groupName">The name of the group we're looking for</param>
        /// <returns>A collection of all the voting events matching the criteria</returns>
        [Route("groupVotes")]
        [HttpGet]
        public IActionResult groupVotes(string groupName)
        {
            return new JsonResult(allVotesLogic.getVotesFromGroup(groupName));
        }

        /// <summary>
        /// Number of unique users within a vote group
        /// </summary>
        /// <param name="groupName">The name of the voteGroup we're looking for</param>
        /// <returns>A collection of all the voting events matching the criteria</returns>
        [Route("participantCount")]
        [HttpGet]
        public IActionResult participantCount(string groupName)
        {
            return new JsonResult(allVotesLogic.numberOfGroupParticipants(groupName));
        }

        /// <summary>
        /// Check if a vote is won.
        /// </summary>
        /// <param name="voteID">The id of the vote to be checked</param>
        /// <remarks>Check if at this moment a vote meets every criteria required to be considered winning. This is not final, just the current state. It can change as more votes are submitted, if the vote is still ongoing. </remarks>
        /// <returns>True if won, false if not</returns>
        [Route("winCheck")]
        [HttpGet]
        public IActionResult winCheck(int voteID)
        {
            return new JsonResult(allVotesLogic.IsVoteWon(voteID));
        }
    }
}
