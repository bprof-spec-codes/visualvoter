using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    interface IOneVoteLogic
    {
        OneVote GetOneUser(int userId);
        IQueryable<OneVote> GetAllUsers();
        void CreateUser(OneVote vote);
        void DeleteUser(int voteId);

        void UpdateUser(int oldId, OneVote newVote);
    }
}
