﻿using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Class
{
    class AllVotesRepository : IAllVotesRepository
    {
        public IQueryable<AllVotes> GetAll()
        {
            throw new NotImplementedException();
        }

        public AllVotes GetOne(string id)
        {
            throw new NotImplementedException();
        }
    }
}
