using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public interface IVotingRightLogic
    {
        IQueryable<VotingRight> GetOne(int voteID);
        bool CreateVotingRight(VotingRight element);
    }
}
