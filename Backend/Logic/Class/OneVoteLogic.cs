using Microsoft.AspNetCore.Identity;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    ///<inheritdoc/>
    public class OneVoteLogic : IOneVoteLogic
    {
        /// <summary>
        /// Repository for the oneVote table
        /// </summary>
        public IOneVoteRepository oneVoteRepo;

        /// <summary>
        /// Repository for the AllVotes table
        /// </summary>
        public IAllVotesLogic allVotesLogic;

        /// <summary>
        /// Creates a new instance of the oneVote logic.
        /// </summary>
        /// <param name="dbPassword">The password used for connecting to the db</param>
        public OneVoteLogic(string dbPassword)
        {
            this.oneVoteRepo = new OneVoteRepository(dbPassword);
            this.allVotesLogic = new AllVotesLogic(dbPassword);
        }
        ///<inheritdoc/>
        public bool CreateOneVote(OneVote vote, string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(vote.voteGroup) || vote.voteGroup.ToLower() == "string") //If we didn't get a votegroup from the frontend for the submitted vote, we look it up on backend side.
                {
                    var associatedVoteGroup = allVotesLogic.GetOneVote(vote.VoteID).voteGroup;
                    vote.voteGroup = associatedVoteGroup;
                }
                if (string.IsNullOrWhiteSpace(vote.submitterName) || vote.voteGroup.ToLower() == "string") // -||-
                {
                    vote.submitterName = name;
                }
                this.oneVoteRepo.Add(vote);
                this.AddUsersChoiceToAllVotes(vote);
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        ///<inheritdoc/>
        public bool DeleteOneVote(int voteId)
        {
            try
            {
                this.oneVoteRepo.Delete(voteId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        ///<inheritdoc/>
        public IQueryable<OneVote> GetAllOneVote()
        {
            return this.oneVoteRepo.GetAll();
        }
        ///<inheritdoc/>
        public OneVote GetOneVote(int userId)
        {
            return this.oneVoteRepo.GetOne(userId);
        }
        ///<inheritdoc/>
        public bool UpdateOneVote(int oldId, OneVote newVote)
        {
            try
            {
                this.oneVoteRepo.Update(oldId, newVote);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        ///<inheritdoc/>
        public AllVotes getAssociatedVote(OneVote input)
        {
           return allVotesLogic.GetOneVote(input.VoteID);
        }
        ///<inheritdoc/>
        public bool canVote(IdentityUser user, OneVote vote)
        {
            var associatedVote = getAssociatedVote(vote);
            return true; //placeholder
        }

        /// <summary>
        /// Increments the associated values in the AllVotes entry, based on what this OneVote has voted for.
        /// </summary>
        /// <param name="vote">The OneVote object to be used to update the values in the AllVotes entry that belongs to it</param>
        void AddUsersChoiceToAllVotes(OneVote vote)
        {
            AllVotes allVoteToSaveChoise = this.allVotesLogic.GetOneVote(vote.VoteID);
            switch (vote.Choice)
            {
                case 0:
                    allVoteToSaveChoise.YesVotes += 1;
                    this.allVotesLogic.UpdateVote(allVoteToSaveChoise.VoteID, allVoteToSaveChoise);
                    break;
                case 1:
                    allVoteToSaveChoise.NoVotes += 1;
                    this.allVotesLogic.UpdateVote(allVoteToSaveChoise.VoteID, allVoteToSaveChoise);
                    break;
                default:
                    allVoteToSaveChoise.AbsentionVotes += 1;
                    this.allVotesLogic.UpdateVote(allVoteToSaveChoise.VoteID, allVoteToSaveChoise);
                    break;
            }
        } 
    }
}
