﻿using Models;
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
        bool CreateVote(AllVotes vote);
        bool DeleteVote(int voteId);
        void CreateNewVote(VoteCreation newVote);
        bool UpdateVote(int oldId, AllVotes newVote);

        IQueryable<AllVotes> GetAllActiveVotes();
    }
}