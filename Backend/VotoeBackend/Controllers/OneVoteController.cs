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
using System.Security.Claims;
using Logic.Class;

namespace VotOEApi.Controllers
{
    /// <summary>
    /// Controller dedicated to management of the individual votes
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class OneVoteController : ControllerBase
    {
        private IOneVoteLogic oneVoteLogic;
        AuthLogic authLogic;

        /// <summary>
        /// Creates a new instance of the OneVote controller
        /// </summary>
        /// <param name="logic">OneVoteLogic object (transient)</param>
        /// <param name="authLogic">AuthLogic object (transient)</param>
        public OneVoteController(IOneVoteLogic logic, AuthLogic authLogic)
        {
            this.oneVoteLogic = logic;
            this.authLogic = authLogic;
        }

        /// <summary>
        /// List all the individual submitted votes
        /// </summary>
        /// <returns>A collection of OneVotes</returns>
        [HttpGet]
        public IEnumerable<OneVote> GetAllOneVotes()
        {
            return this.oneVoteLogic.GetAllOneVote();
        }

        /// <summary>
        /// Gets a single specified vote
        /// </summary>
        /// <param name="id">The id of the vote in question</param>
        /// <returns>A single OneVote object</returns>
        [HttpGet("{id:int}")]
        public OneVote GetOneVote(int id)
        {
            return this.oneVoteLogic.GetOneVote(id);
        }

        /// <summary>
        /// Delete a single vote
        /// </summary>
        /// <param name="id">The id of the vote to be deleted</param>
        [HttpDelete("{id}")]
        public void DeleteVote(int id)
        {
            this.oneVoteLogic.DeleteOneVote(id);
        }

        /// <summary>
        /// Submit a new vote
        /// </summary>
        /// <param name="vote">OneVote object, containing the details of the vote to be submitted</param>
        /// <returns>Http200 if successful, 401, if the user doesn't have the roles needed for this vote</returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SubmitVote([FromBody] OneVote vote)
        {
            var associatedVote = this.oneVoteLogic.getAssociatedVote(vote);
            var userName = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //if (this.User.IsInRole(associatedVote.RequiredRole))
            if (await this.authLogic.HasRoleByName(userName,associatedVote.RequiredRole))
            {
                this.oneVoteLogic.CreateOneVote(vote, userName);

                //Code is correct but still stays in that role after removing.
                await this.authLogic.RemoveUserFromRole(userName, associatedVote.RequiredRole);
                //this.authLogic.RemoveUserFromRole(this.User.Identity.Name, associatedVote.RequiredRole);



                //TODO Fix this to use the lines below instead of requiring an instance of authlogic
                //These lines of command work, but for some reason at the next request the role is still on the user after it was remove here.
                /*var role = ((ClaimsIdentity)User.Identity).Claims
                        .Where(c => c.Type == ClaimTypes.Role && c.Value == associatedVote.RequiredRole)
                        .FirstOrDefault();

                var identity = this.User.Identity as ClaimsIdentity;
                identity.RemoveClaim(role);*/





                return Ok();
            }
            return Unauthorized();
        }

        /*[Authorize(Roles = "Admin,Editor,Hallgató")]
        [HttpPost]
        public IActionResult SubmitVote([FromBody] OneVote vote)
        {
            var associatedVote = this.oneVoteLogic.getAssociatedVote(vote);
            if (this.User.IsInRole(associatedVote.RequiredRole))
            {
                this.oneVoteLogic.CreateOneVote(vote);
                return Ok();
            }
            return Unauthorized();
        }*/

        /// <summary>
        /// Updates a single vote
        /// </summary>
        /// <param name="oldId">Original id of the vote</param>
        /// <param name="vote">OneVote Object, containing the details of the vote to be updated</param>
        /// <returns>Http200 if ok, 400 if not</returns>
        [HttpPut("{oldId}")]
        public IActionResult UpdateVote(int oldId, [FromBody] OneVote vote)
        {
            if (this.oneVoteLogic.UpdateOneVote(oldId, vote)) return Ok();
            else return BadRequest();
        }
    }
}
