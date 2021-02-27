using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    class AllVotesLogic : IAllVotesLogic
    {
        public IAllVotesRepository allVotesRepo;

        public AllVotesLogic(string dbPassword)
        {
            this.allVotesRepo = new AllVotesRepository(dbPassword);
        }

        public void CreateUser(AllVotes vote)
        {
            this.allVotesRepo.Add(vote);
        }

        public void DeleteUser(int voteId)
        {
            this.allVotesRepo.Delete(voteId);
        }

        public IQueryable<AllVotes> GetAllUsers()
        {
            return this.allVotesRepo.GetAll();
        }

        public AllVotes GetOneUser(int voteId)
        {
            return this.allVotesRepo.GetOne(voteId);
        }

        public void UpdateUser(int oldId, AllVotes newVote)
        {
            this.allVotesRepo.Update(oldId, newVote);
        }
    }
}
