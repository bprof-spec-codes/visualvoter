﻿using Data;
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
            throw new NotImplementedException();
        }

        public void Delete(AllVotes element)
        {
            throw new NotImplementedException();
        }

        public IQueryable<AllVotes> GetAll()
        {
            throw new NotImplementedException();
        }

        public AllVotes GetOne(string key)
        {
            throw new NotImplementedException();
        }

        public void Update(AllVotes element)
        {
            throw new NotImplementedException();
        }
    }
}
