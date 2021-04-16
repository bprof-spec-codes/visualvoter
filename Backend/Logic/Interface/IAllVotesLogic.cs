﻿using Microsoft.AspNetCore.Identity;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Logic for handling the main voting events
    /// </summary>
    public interface IAllVotesLogic
    {
        /// <summary>
        /// Returns a single specified "voting event"
        /// </summary>
        /// <param name="voteId">The id of the vote to return</param>
        /// <returns>One AllVotes entry</returns>
        AllVotes GetOneVote(int voteId);
        /// <summary>
        /// Returns all the "voting events"
        /// </summary>
        /// <returns>All the AllVotes in the db</returns>
        IQueryable<AllVotes> GetAllVotes();

        /// <summary>
        /// Method for creating a new voting event
        /// </summary>
        /// <param name="vote">The AllVotes object to create</param>
        /// <returns>True if successful, false if not</returns>
        bool CreateVote(AllVotes vote);

        /// <summary>
        /// Deletes a voting event
        /// </summary>
        /// <param name="voteId">ID of the voting event to delete</param>
        /// <returns>True if successful, false if not</returns>
        bool DeleteVote(int voteId);

        /// <summary>
        /// Updates a voting event
        /// </summary>
        /// <param name="oldId">Previous id of the voting event</param>
        /// <param name="newVote">AllVotes object, to be updated</param>
        /// <returns>True if successful, false if not</returns>
        bool UpdateVote(int oldId, AllVotes newVote);

        /// <summary>
        /// Creates a list of all the votes that are currently active.
        /// </summary>
        /// <returns>Collection of all the active voting events</returns>
        IQueryable<AllVotes> GetAllActiveVotes();

        /// <summary>
        /// Returns a list of all the votes that can be voted on by the list of roles provided as a parameter.
        /// </summary>
        /// <param name="roles">List of roles to be checked</param>
        /// <returns>List of all the votes that meet the criteria</returns>
        List<AllVotes> GetAllAvaliableVotes(List<string> roles);

        /// <summary>
        /// Marks a specified vote as closed
        /// </summary>
        /// <param name="id">The id of the vote to be closed</param>
        /// <returns>True if successful, false if not</returns>
        public bool CloseAVote(int id);

        /// <summary>
        /// Marks a specified vote as finished
        /// </summary>
        /// <param name="id">Id of the vote to be marked as finished</param>
        /// <returns>True if successful, false if not</returns>
        public bool FinishAVote(int id);
    }
}
