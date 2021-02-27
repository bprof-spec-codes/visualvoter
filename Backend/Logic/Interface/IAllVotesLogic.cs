using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public interface IAllVotesLogic
    {
        AllVotes GetOneVote(int voteId);
        IQueryable<AllVotes> GetAllVotes();
        void CreateVote(AllVotes vote);
        void DeleteVote(int voteId);

        void UpdateVote(int oldId, AllVotes newVote);
    }
}
