﻿using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class OneVoteLogic : IOneVoteLogic
    {
        public IOneVoteRepository oneVoteRepo;
        public IAllVotesLogic allVotesLogic;

        public OneVoteLogic(string dbPassword)
        {
            this.oneVoteRepo = new OneVoteRepository(dbPassword);
            this.allVotesLogic = new AllVotesLogic(dbPassword);
        }
        public bool CreateOneVote(OneVote vote)
        {
            if (!CanVote(vote)) return false;
            try
            {
                this.oneVoteRepo.Add(vote);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteOneVote(int voteId)
        {
            //this.oneVoteRepo.Delete(voteId);
            try
            {
                this.oneVoteRepo.Delete(voteId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IQueryable<OneVote> GetAllOneVote()
        {
            return this.oneVoteRepo.GetAll();
        }

        public OneVote GetOneVote(int userId)
        {
            return this.oneVoteRepo.GetOne(userId);
        }

        public bool UpdateOneVote(int oldId, OneVote newVote)
        {
            //this.oneVoteRepo.Update(oldId, newVote);
            try
            {
                this.oneVoteRepo.Update(oldId, newVote);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool CanVote(OneVote vote)
        {
            throw new NotImplementedException();
        }

        private bool GetUsersVoteHistory(int userID, int voteID)
        {
            var query = from x in oneVoteRepo.GetAll()
                        where x.UserID == userID && x.VoteID == voteID
                        select x;
            return query.Count() == 0;
        }
    }
}