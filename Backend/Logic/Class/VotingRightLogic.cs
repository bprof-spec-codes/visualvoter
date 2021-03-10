using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class VotingRightLogic : IVotingRightLogic
    {
        public IVotingRightRepository vrRepo;

        public VotingRightLogic(string dbPassword)
        {
            this.vrRepo = new VotingRightRepository(dbPassword);
        }

        public bool CreateVotingRight(VotingRight element)
        {
            try
            {
                this.vrRepo.Add(element);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IQueryable<VotingRight> GetOne(int voteID)
        {
            return this.vrRepo.GetOne(voteID);
        }
    }
}
