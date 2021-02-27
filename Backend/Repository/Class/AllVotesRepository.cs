using Data;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Class
{
    class AllVotesRepository : IAllVotesRepository
    {
        private VotoeDbContext db;

        public AllVotesRepository(VotoeDbContext db)
        {
            this.db = db;
        }

        public void Add(AllVotes element)
        {
            db.Add(element);
            db.SaveChanges();
        }

        public void Delete(AllVotes element)
        {
            db.Remove(element);
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

        public void Update(AllVotes element) //Might not work, untested TODO_lux
        {
            throw new NotImplementedException();
            var temp = GetOne(element.VoteID);
            if (temp != null)
            {
                temp = element;
                db.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void Update(int oldKey, AllVotes element)
        {
            throw new NotImplementedException();
        }
    }
}
