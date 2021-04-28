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
        /// Repository for the oneVote table
        /// </summary>
        public IOneVoteRepository oneVoteRepository;

        /// <summary>
        /// Creates an instance of the AllVotesLogic
        /// </summary>
        /// <param name="dbPassword">Database password string</param>
        public AllVotesLogic(string dbPassword)
        {
            this.allVotesRepo = new AllVotesRepository(dbPassword);
            this.oneVoteRepository = new OneVoteRepository(dbPassword);
        }
        ///<inheritdoc/>
        public bool CreateVote(AllVotes vote)
        {
            //this.allVotesRepo.Add(vote);

            this.allVotesRepo.Add(vote);
            return true;

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
            var matchingOneVotes = oneVoteRepository.GetAll().Where(x => x.voteGroup == groupName).Select(x => x.submitterName); //Todo: untested

            return matchingOneVotes.Distinct().Count();
        }
        ///<inheritdoc/>
        public int numberOfVotesInGroup(string groupName)
        {
            var matchingOneVotes = oneVoteRepository.GetAll().Where(x => x.voteGroup == groupName);

            return matchingOneVotes.Count();
        }
        ///<inheritdoc/>
        public bool IsVoteWon(int voteID)
        {
            //According to the .pdf, a vote is won, when 
            // - 1.) It has the most yes votes in it's voting group,
            //AND
            // - 2.) 2/3 of the voters, who submitted a vote to this, or any other candidate in the same voting group, voted 'Yes' to this candidate.

            

            var thisVote = this.GetOneVote(voteID);

            if (string.IsNullOrWhiteSpace(thisVote.voteGroup) || thisVote.voteGroup.ToLower() == "string")
            {
                var totalVotes = thisVote.YesVotes + thisVote.NoVotes + thisVote.AbsentionVotes;
                var twoThird = totalVotes / 3.0 * 2.0;
                if (thisVote.YesVotes >= twoThird)
                {
                    return true;
                }
                return false;
            }

            bool mostYesVoted_Condition = false; // 1.)
            bool twoThird_Condition = false;         // 2.)

            var otherVotesInSameGroup = getVotesFromGroup(thisVote.voteGroup);
            int maxYesVotesInGroup = -1;
            foreach (var item in otherVotesInSameGroup)
            {
                if (item.YesVotes > maxYesVotesInGroup)
                {
                    maxYesVotesInGroup = item.YesVotes;
                }
            }
            if (thisVote.YesVotes >= maxYesVotesInGroup)
            {
                mostYesVoted_Condition = true;
            }

            int participantNumber = this.numberOfGroupParticipants(thisVote.voteGroup);
            double twoThirds = participantNumber / 3.0 * 2.0;
            if (thisVote.YesVotes >= twoThirds)
            {
                twoThird_Condition = true;
            }
            return mostYesVoted_Condition && twoThird_Condition;
        }
    }
}
