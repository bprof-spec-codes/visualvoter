using Data;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class AllVotesRepository : IAllVotesRepository
    {
        private VotoeDbContext db;

        public AllVotesRepository(string dbPassword)
        {
            this.db = new VotoeDbContext(dbPassword);
        }

        public void Add(AllVotes element)
        {
            db.Add(element);
            db.SaveChanges();
        }

        public void Delete(int key)
        {
            db.Remove(this.GetOne(key));
            db.SaveChanges();
        }

        public IQueryable<AllVotes> GetAll()
        {
            return db.AllVotes;
        }

        public AllVotes GetOne(int key)
        {
            var output = db.AllVotes.Where(x => x.VoteID == key).SingleOrDefault();
            return output;
        }

        public void Update(int oldKey, AllVotes element)
        {
            var oldVote = this.GetOne(oldKey);
            oldVote = element;
            this.db.SaveChanges();
        }

        public int GetLastVote()
        {
            return this.db.AllVotes.Max(x => x.VoteID);
        }
    }
}
