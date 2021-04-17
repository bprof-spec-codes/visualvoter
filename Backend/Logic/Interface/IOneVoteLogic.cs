using Microsoft.AspNetCore.Identity;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Logic for managing single votes
    /// </summary>
    public interface IOneVoteLogic
    {
        /// <summary>
        /// returns a single specified vote
        /// </summary>
        /// <param name="userId">Id of the vote to be returned</param>
        /// <returns>A single OneVote object</returns>
        OneVote GetOneVote(int userId);
        /// <summary>
        /// Gets all the single votes that have been submitted
        /// </summary>
        /// <returns>A collection of all the OneVotes</returns>
        IQueryable<OneVote> GetAllOneVote();
        /// <summary>
        /// Submits a new vote
        /// </summary>
        /// <param name="vote">OneVote object, containing the details of the vote to be submitted</param>
        /// <param name="name">Username of the user</param>
        /// <returns>True if successful, false if not</returns>
        bool CreateOneVote(OneVote vote, string name);
        /// <summary>
        /// Deletes a specified vote
        /// </summary>
        /// <param name="voteId">Id of the vote to be deleted</param>
        /// <returns>True if successful, false if not</returns>
        bool DeleteOneVote(int voteId);

        /// <summary>
        /// Updates a specified vote
        /// </summary>
        /// <param name="oldId">Original id of the vote to be updated</param>
        /// <param name="newVote">OneVote object, with the already updated details</param>
        /// <returns>True if successful, false if not</returns>
        /// 
        bool UpdateOneVote(int oldId, OneVote newVote);
        /// <summary>
        /// TODO PLACEHOLDER
        /// </summary>
        /// <param name="user">PLACEHOLDER</param>
        /// <param name="vote">PLACEHOLDER</param>
        /// <returns>True if can vote, false if not?</returns>
        bool canVote(IdentityUser user, OneVote vote);

        /// <summary>
        /// Gets the AllVotes "voting event" associated with a specific vote
        /// </summary>
        /// <param name="input">OneVote object, to be checked</param>
        /// <returns>The associated AllVotes object</returns>
        AllVotes getAssociatedVote(OneVote input);
    }
}
