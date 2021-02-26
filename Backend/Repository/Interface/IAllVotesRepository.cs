using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interface
{
    public interface IAllVotesRepository : IRepository<AllVotes, string>
    {
        AllVotes GetOne(string id);

        IQueryable<AllVotes> GetAll();
    }
}
