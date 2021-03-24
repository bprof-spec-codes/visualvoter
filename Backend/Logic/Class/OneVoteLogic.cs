using Microsoft.AspNetCore.Identity;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class OneVoteLogic : IOneVoteLogic
    {
        public IOneVoteRepository oneVoteRepo;
        public IAllVotesLogic allVotesLogic;

        public OneVoteLogic(string dbPassword)
        {
            this.oneVoteRepo = new OneVoteRepository(dbPassword);
            this.allVotesLogic = new AllVotesLogic(dbPassword);
        }
        public bool CreateOneVote(OneVote vote)
        {
            try
            {
                this.oneVoteRepo.Add(vote);
                this.AddUsersChoiceToAllVotes(vote);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteOneVote(int voteId)
        {
            //this.oneVoteRepo.Delete(voteId);
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

        public IQueryable<OneVote> GetAllOneVote()
        {
            return this.oneVoteRepo.GetAll();
        }

        public OneVote GetOneVote(int userId)
        {
            return this.oneVoteRepo.GetOne(userId);
        }

        public bool UpdateOneVote(int oldId, OneVote newVote)
        {
            //this.oneVoteRepo.Update(oldId, newVote);
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

        /*private bool GetUsersVoteHistory(int userID, int voteID)
        {
            var query = from x in oneVoteRepo.GetAll()
                        where x.UserID == userID && x.VoteID == voteID
                        select x;
            return query.Count() == 0;
        }*/

        public AllVotes getAssociatedVote(OneVote input)
        {
           return allVotesLogic.GetOneVote(input.VoteID);
        }

        public bool canVote(IdentityUser user, OneVote vote)
        {
            var associatedVote = getAssociatedVote(vote);
            return true; //placeholder
        }

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
