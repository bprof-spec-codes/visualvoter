using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    interface IAllVotesLogic
    {
        AllVotes GetOneUser(int voteId);
        IQueryable<AllVotes> GetAllUsers();
        void CreateUser(AllVotes vote);
        void DeleteUser(int voteId);

        void UpdateUser(int oldId, AllVotes newVote);
    }
}
