using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public interface IVotingRightRepository : IRepository<VotingRight,int>
    {
        public new IQueryable<VotingRight> GetOne(int key);
    }
}
