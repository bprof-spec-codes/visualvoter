using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class VoteCreation
    {
        public AllVotes NewVote { get; set; }
        public int[] WhoCanVote { get; set; }
    }
}
