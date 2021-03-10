using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public interface IAllVotesRepository : IRepository<AllVotes, int>
    {
        public int GetLastVote();
    }
}
