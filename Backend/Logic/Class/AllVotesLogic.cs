using Logic.Interface;
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
    public class AllVotesLogic : IAllVotesLogic
    {
        /// <summary>
        /// Repository for the allVotes table
        /// </summary>
        public IAllVotesRepository allVotesRepo;
        /// <summary>
        /// Logic for the OneVote related methods.
        /// </summary>
        public IOneVoteLogic oneVoteLogic;


        /// <summary>
        /// Creates an instance of the AllVotesLogic
        /// </summary>
        /// <param name="dbPassword">Database password string</param>
        public AllVotesLogic(string dbPassword)
        {
            this.allVotesRepo = new AllVotesRepository(dbPassword);
            this.oneVoteLogic = new OneVoteLogic(dbPassword);
        }
        ///<inheritdoc/>
        public bool CreateVote(AllVotes vote)
        {
            //this.allVotesRepo.Add(vote);
            try
            {
                this.allVotesRepo.Add(vote);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        ///<inheritdoc/>
        public bool DeleteVote(int voteId)
        {

            //this.allVotesRepo.Delete(voteId);
            try
            {
                this.allVotesRepo.Delete(voteId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        ///<inheritdoc/>
        public IQueryable<AllVotes> GetAllVotes()
        {
            return this.allVotesRepo.GetAll();
        }
        ///<inheritdoc/>
        public AllVotes GetOneVote(int voteId)
        {
            return this.allVotesRepo.GetOne(voteId);
        }
        ///<inheritdoc/>
        public bool UpdateVote(int oldId, AllVotes newVote)
        {
            //this.allVotesRepo.Update(oldId, newVote);
            try
            {
                this.allVotesRepo.Update(oldId, newVote);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        ///<inheritdoc/>
        public IQueryable<AllVotes> GetAllActiveVotes()
        {
            return this.allVotesRepo.GetAll().Where(x => x.IsClosed == 0 && x.IsFinished == 0);
        }
        ///<inheritdoc/>
        public List<AllVotes> GetAllAvaliableVotes(List<string> roles)
        {
            List<AllVotes> output = new List<AllVotes>();
            foreach (var item in this.GetAllVotes())
            {
                if (roles.Contains(item.RequiredRole))
                {
                    output.Add(item);
                }
            }
            return output;
        }
        ///<inheritdoc/>
        public bool CloseAVote(int id)
        {
            try
            {
                var vote = this.allVotesRepo.GetOne(id);
                _ = vote.IsClosed == 0 ? vote.IsClosed = 1 : vote.IsClosed = 0;
                this.allVotesRepo.Update(id, vote);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        ///<inheritdoc/>
        public bool FinishAVote(int id)
        {
            try
            {
                var vote = this.allVotesRepo.GetOne(id);
                vote.IsFinished = 1;
                this.allVotesRepo.Update(id, vote);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        ///<inheritdoc/>
        public List<AllVotes> getVotesFromGroup(string groupName)
        {
           var matchingAllVotes = GetAllVotes().Where(x => x.voteGroup == groupName);
            return matchingAllVotes.ToList();
        }
        ///<inheritdoc/>
        public int numberOfGroupParticipants(string groupName)
        {

            var matchingOneVotes = oneVoteLogic.GetAllOneVote().Where(x => x.voteGroup == groupName).Select(x => x.submitterEmail); //Todo: untested

            return matchingOneVotes.Distinct().Count();
        }
        ///<inheritdoc/>
        public int numberOfVotesInGroup(string groupName)
        {
            var matchingOneVotes = oneVoteLogic.GetAllOneVote().Where(x => x.voteGroup == groupName);

            return matchingOneVotes.Count();
        }
    }
}
