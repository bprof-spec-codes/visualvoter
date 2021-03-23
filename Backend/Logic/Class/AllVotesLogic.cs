using Microsoft.AspNetCore.Identity;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class AllVotesLogic : IAllVotesLogic
    {
        public IAllVotesRepository allVotesRepo;

        public AllVotesLogic(string dbPassword)
        {
            this.allVotesRepo = new AllVotesRepository(dbPassword);
        }

        public bool CreateVote(VoteCreation vote)
        {
            //this.allVotesRepo.Add(vote);
            try
            {
                this.allVotesRepo.Add(vote.NewVote);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteVote(int voteId)
        {

            //this.allVotesRepo.Delete(voteId);
            try
            {
                this.allVotesRepo.Delete(voteId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IQueryable<AllVotes> GetAllVotes()
        {
            return this.allVotesRepo.GetAll();
        }

        public AllVotes GetOneVote(int voteId)
        {
            return this.allVotesRepo.GetOne(voteId);
        }

        public bool UpdateVote(int oldId, AllVotes newVote)
        {
            //this.allVotesRepo.Update(oldId, newVote);
            try
            {
                this.allVotesRepo.Update(oldId, newVote);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IQueryable<AllVotes> GetAllActiveVotes()
        {
            return this.allVotesRepo.GetAll().Where(x => x.IsClosed == 0 && x.IsFinished == 0);
        }

        public List<AllVotes> getAllAvaliableVotes(List<string> roles)
        {
            List<AllVotes> output = new List<AllVotes>();
            foreach (var item in this.GetAllVotes())
            {
                if (roles.Contains(item.RequiredRole))
                {
                    output.Add(item);
                }
            }
            return output;
        }
    }
}
