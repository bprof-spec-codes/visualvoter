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

        public AllVotesLogic(string dbPassword)
        {
            this.allVotesRepo = new AllVotesRepository(dbPassword);
        }

        public void CreateVote(AllVotes vote)
        {
            this.allVotesRepo.Add(vote);
        }

        public void DeleteVote(int voteId)
        {
            this.allVotesRepo.Delete(voteId);
        }

        public IQueryable<AllVotes> GetAllVotes()
        {
            return this.allVotesRepo.GetAll();
        }

        public AllVotes GetOneVote(int voteId)
        {
            return this.allVotesRepo.GetOne(voteId);
        }

        public void UpdateVote(int oldId, AllVotes newVote)
        {
            this.allVotesRepo.Update(oldId, newVote);
        }
    }
}
