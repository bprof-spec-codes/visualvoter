using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Class
{
    class OneVoteLogic : IOneVoteLogic
    {
        public IOneVoteRepository oneVoteRepo;

        public OneVoteLogic(string dbPassword)
        {
            this.oneVoteRepo = new OneVoteRepository(dbPassword);
        }
        public void CreateUser(OneVote vote)
        {
            this.oneVoteRepo.Add(vote);
        }

        public void DeleteUser(int voteId)
        {
            this.oneVoteRepo.Delete(voteId);
        }

        public IQueryable<OneVote> GetAllUsers()
        {
            return this.oneVoteRepo.GetAll();
        }

        public OneVote GetOneUser(int userId)
        {
            return this.oneVoteRepo.GetOne(userId);
        }

        public void UpdateUser(int oldId, OneVote newVote)
        {
            this.oneVoteRepo.Update(oldId, newVote);
        }
    }
}
