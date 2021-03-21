using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class AllVotesLogic : IAllVotesLogic
    {
        public IAllVotesRepository allVotesRepo;
        public IVotingRightLogic vrLogic;

        public AllVotesLogic(string dbPassword)
        {
            this.allVotesRepo = new AllVotesRepository(dbPassword);
        }

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

        public IQueryable<AllVotes> GetAllVotes()
        {
            return this.allVotesRepo.GetAll();
        }

        public AllVotes GetOneVote(int voteId)
        {
            return this.allVotesRepo.GetOne(voteId);
        }

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

        public void CreateNewVote(VoteCreation newVote) //TODO CHECK IF USER HAS THE RIGHT
        {
            if (CreateVote(newVote.NewVote))
            {
                int lastVoteID = this.allVotesRepo.GetLastVote();
                foreach (int userTypeID in newVote.WhoCanVote)
                {
                    VotingRight tempVR = new VotingRight()
                    {
                        UserTypeID = userTypeID,
                        VoteID = lastVoteID,
                    };
                    this.vrLogic.CreateVotingRight(tempVR);
                }
            }
        }

        public IQueryable<AllVotes> GetAllActiveVotes()
        {
            return this.allVotesRepo.GetAll().Where(x => x.IsClosed == 0 && x.IsFinished == 0);
        }
    }
}
