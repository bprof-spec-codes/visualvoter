using Data;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
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

        public void Delete(int Id)
        {
            this.db.Remove(this.GetOne(Id));
            db.SaveChanges();
        }

        public IQueryable<OneVote> GetAll()
        {
            return this.db.OneVote;
        }

        public OneVote GetOne(int key)
        {
            var output = GetAll().Where(x => x.OneVoteID == key).SingleOrDefault();
            return output;
        }

        public void Update(OneVote element)
        {
            throw new NotImplementedException();
        }

        public void Update(int oldKey, OneVote element)
        {
            throw new NotImplementedException();
        }
    }
}
