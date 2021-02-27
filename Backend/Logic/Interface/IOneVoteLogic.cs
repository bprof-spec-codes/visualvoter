using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public interface IOneVoteLogic
    {
        OneVote GetOneVote(int userId);
        IQueryable<OneVote> GetAllOneVote();
        void CreateOneVote(OneVote vote);
        void DeleteOneVote(int voteId);

        void UpdateOneVote(int oldId, OneVote newVote);
    }
}
