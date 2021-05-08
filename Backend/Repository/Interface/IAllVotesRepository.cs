using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    /// <summary>
    /// Repository for handling AllVotes related data
    /// </summary>
    public interface IAllVotesRepository : IRepository<AllVotes, int>
    {
        /// <summary>
        /// TODO Update this summary
        /// </summary>
        /// <returns>The last vote?</returns>
        public int GetLastVote();
    }
}
