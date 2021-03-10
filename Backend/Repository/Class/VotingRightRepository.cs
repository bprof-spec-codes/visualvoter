using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Class
{
    class VotingRightRepository : IVotingRightRepository
    {
        private VotoeDbContext db;

        public VotingRightRepository(string dbPassword)
        {
            this.db = new VotoeDbContext(dbPassword);
        }

        public void Add(VotingRight element)
        {
            this.db.Add(element);
            this.db.SaveChanges();
        }

        public void Delete(int element)
        {
            this.db.Remove(element);
            this.db.SaveChanges();
        }

        public IQueryable<VotingRight> GetAll()
        {
            return this.db.VotingRight;
        }

        // its possible that multiple usertypes can vote
        public IQueryable<VotingRight> GetOne(int key)
        {
            return this.db.VotingRight.Where(x => x.VoteID == key);
        }

        public void Update(int oldKey, VotingRight element)
        {
            throw new NotImplementedException();
        }

        //ignore this?
        VotingRight IRepository<VotingRight, int>.GetOne(int key)
        {
            throw new NotImplementedException();
        }
    }
}
