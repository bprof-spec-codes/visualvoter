using Data;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Class
{  
    class OneVoteRepository : IOneVoteRepository
    {
        private VotoeDbContext db;
        public OneVoteRepository(VotoeDbContext db)
        {
            this.db = db;
        }

        public void Add(OneVote element)
        {
            db.Add(element);
            db.SaveChanges();
        }

        public void Delete(OneVote element)
        {
            db.Remove(element);
            db.SaveChanges();
        }

        public IQueryable<OneVote> GetAll()
        {
            return this.db.OneVote;
        }

        public OneVote GetOne(string key)
        {
            var output = GetAll().Where(x => x.OneVoteID == key).SingleOrDefault();
            return output;
        }

        public void Update(OneVote element)
        {
            throw new NotImplementedException();
        }
    }
}
