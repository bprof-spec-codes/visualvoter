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
        public IVotingRightLogic vrLogic;
        public IUsersLogic usersLogic;

        public OneVoteLogic(string dbPassword)
        {
            this.oneVoteRepo = new OneVoteRepository(dbPassword);
            this.allVotesLogic = new AllVotesLogic(dbPassword);
            this.vrLogic = new VotingRightLogic(dbPassword);
            this.usersLogic = new UsersLogic(dbPassword);
        }
        public bool CreateOneVote(OneVote vote)
        {
            if (!CanVote(vote)) return false;
            try
            {
                this.oneVoteRepo.Add(vote);
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

        private bool CanVote(OneVote vote)
        {
            var userTypesWhoCanVote = this.vrLogic.GetOne(vote.VoteID);
            var userTypeID = this.usersLogic.GetOneUser(vote.UserID).UserTypeID;
            foreach(var votingRightsRow in userTypesWhoCanVote)
            {
                if(votingRightsRow.UserTypeID == userTypeID) // true = the user can vote
                {
                    //check if voted before
                    if (GetUsersVoteHistory(vote.UserID, vote.VoteID))
                    {
                        var voteRow = this.allVotesLogic.GetOneVote(vote.VoteID);
                        switch (vote.Choice)
                        {
                            case 0:
                                voteRow.YesVotes += 1;
                                this.allVotesLogic.UpdateVote(voteRow.VoteID, voteRow);
                                break;
                            case 1:
                                voteRow.NoVotes += 1;
                                this.allVotesLogic.UpdateVote(voteRow.VoteID, voteRow);
                                break;
                            case 2:
                                voteRow.AbsentionVotes += 1;
                                this.allVotesLogic.UpdateVote(voteRow.VoteID, voteRow);
                                break;
                            default: return false;
                        }
                        return true;
                    }
                    else return false;
                }
            }
            return false;
        }

        private bool GetUsersVoteHistory(int userID, int voteID)
        {
            var query = from x in oneVoteRepo.GetAll()
                        where x.UserID == userID && x.VoteID == voteID
                        select x;
            return query.Count() == 0;
        }
    }
}
