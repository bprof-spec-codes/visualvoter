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
    public class OneVoteRepository : IOneVoteRepository
    {
        private VotoeDbContext db;
        /// <summary>
        /// Creates a new instance of the oneVote repo
        /// </summary>
        /// <param name="dbPassword">Password for the db</param>
        public OneVoteRepository(string dbPassword)
        {
            this.db = new VotoeDbContext(dbPassword);
        }
        ///<inheritdoc/>
        public void Add(OneVote element)
        {
            db.Add(element);
            db.SaveChanges();
        }
        ///<inheritdoc/>
        public void Delete(int Id)
        {
            this.db.Remove(this.GetOne(Id));
            db.SaveChanges();
        }
        ///<inheritdoc/>
        public IQueryable<OneVote> GetAll()
        {
            return this.db.OneVote;
        }
        ///<inheritdoc/>
        public OneVote GetOne(int key)
        {
            var output = GetAll().Where(x => x.OneVoteID == key).SingleOrDefault();
            return output;
        }
        ///<inheritdoc/>
        public void Update(int oldKey, OneVote element)
        {
            var oldVote = this.GetOne(oldKey);
            oldVote = element;
            this.db.SaveChanges();
        }
    }
}
