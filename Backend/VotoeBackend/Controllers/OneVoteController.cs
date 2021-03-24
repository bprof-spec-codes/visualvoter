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
    [Route("[controller]")]
    [ApiController]
    public class OneVoteController : ControllerBase
    {
        private IOneVoteLogic oneVoteLogic;
        AuthLogic authLogic;

        public OneVoteController(IOneVoteLogic logic, AuthLogic authLogic)
        {
            this.oneVoteLogic = logic;
            this.authLogic = authLogic;
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SubmitVote([FromBody] OneVote vote)
        {
            var associatedVote = this.oneVoteLogic.getAssociatedVote(vote);
            var userName = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //if (this.User.IsInRole(associatedVote.RequiredRole))
            if (await this.authLogic.HasRoleByName(userName,associatedVote.RequiredRole))
            {
                //this.oneVoteLogic.CreateOneVote(vote);

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

        [HttpPut("{oldId}")]
        public IActionResult UpdateVote(int oldId, [FromBody] OneVote vote)
        {
            if (this.oneVoteLogic.UpdateOneVote(oldId, vote)) return Ok();
            else return BadRequest();
        }
    }
}
