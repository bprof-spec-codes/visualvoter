using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interface
{
    public interface IOneVoteRepo : IRepository<OneVote, string>
    {
        OneVote GetOne(string input);

        IQueryable<OneVote> GetAll();
    }
}
