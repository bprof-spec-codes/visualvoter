﻿using Microsoft.AspNetCore.Identity;
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
        bool CreateVote(VoteCreation vote);
        bool DeleteVote(int voteId);
        bool UpdateVote(int oldId, AllVotes newVote);

        IQueryable<AllVotes> GetAllActiveVotes();
        List<AllVotes> getAllAvaliableVotes(List<string> roles);
    }
}
