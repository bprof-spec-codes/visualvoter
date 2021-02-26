using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Class
{
    class OneVoteRepo : IOneVoteRepo
    {
        public IQueryable<OneVote> GetAll()
        {
            throw new NotImplementedException();
        }

        public OneVote GetOne(string input)
        {
            throw new NotImplementedException();
        }
    }
}
