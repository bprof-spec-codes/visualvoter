using Data;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    ///<inheritdoc/>
    public class AllVotesRepository : IAllVotesRepository
    {
        private VotoeDbContext db;

        /// <summary>
        /// Creates a new instance of the AllVotes repo
        /// </summary>
        /// <param name="dbPassword">The password for the db</param>
        public AllVotesRepository(string dbPassword)
        {
            this.db = new VotoeDbContext(dbPassword);
        }
        ///<inheritdoc/>
        public void Add(AllVotes element)
        {
            db.Add(element);
            db.SaveChanges();
        }
        ///<inheritdoc/>
        public void Delete(int key)
        {
            db.Remove(this.GetOne(key));
            db.SaveChanges();
        }
        ///<inheritdoc/>
        public IQueryable<AllVotes> GetAll()
        {
            return db.AllVotes;
        }
        ///<inheritdoc/>
        public AllVotes GetOne(int key)
        {
            var output = db.AllVotes.Where(x => x.VoteID == key).SingleOrDefault();
            return output;
        }
        ///<inheritdoc/>
        public void Update(int oldKey, AllVotes element)
        {
            var oldVote = this.GetOne(oldKey);
            oldVote = element;
            this.db.SaveChanges();
        }
        ///<inheritdoc/>
        public int GetLastVote()
        {
            return this.db.AllVotes.Max(x => x.VoteID);
        }
    }
}
