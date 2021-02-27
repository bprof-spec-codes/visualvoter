using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Class
{
    public class OneVoteLogic : IOneVoteLogic
    {
        public IOneVoteRepository oneVoteRepo;

        public OneVoteLogic(string dbPassword)
        {
            this.oneVoteRepo = new OneVoteRepository(dbPassword);
        }
        public void CreateOneVote(OneVote vote)
        {
            this.oneVoteRepo.Add(vote);
        }

        public void DeleteOneVote(int voteId)
        {
            this.oneVoteRepo.Delete(voteId);
        }

        public IQueryable<OneVote> GetAllOneVote()
        {
            return this.oneVoteRepo.GetAll();
        }

        public OneVote GetOneVote(int userId)
        {
            return this.oneVoteRepo.GetOne(userId);
        }

        public void UpdateOneVote(int oldId, OneVote newVote)
        {
            this.oneVoteRepo.Update(oldId, newVote);
        }
    }
}
