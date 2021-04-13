using Microsoft.AspNetCore.Identity;
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
        bool CreateOneVote(OneVote vote);
        bool DeleteOneVote(int voteId);

        bool UpdateOneVote(int oldId, OneVote newVote);
        AllVotes getAssociatedVote(OneVote input);
    }
}
