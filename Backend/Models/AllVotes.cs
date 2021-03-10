using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class AllVotes
    {
        /// <summary>
        /// Unique id for this voting "session"
        /// </summary>
        /// 
        [Key]
        public int VoteID { get; set; }

        /// <summary>
        /// User readable name of the vote
        /// </summary>
        public string VoteName { get; set; }

        /// <summary>
        /// When will the current vote expire
        /// </summary>
        //public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Used to check if this specific vote is closed
        /// </summary>
        public int IsClosed { get; set; }

        /// <summary>
        /// Used to check if this specific vote is finished
        /// </summary>
        public int IsFinished { get; set; }

        /// <summary>
        /// Number of 'yes' choices for this vote
        /// </summary>
        public int YesVotes { get; set; }

        /// <summary>
        /// Number of 'no' choices for this vote
        /// </summary>
        public int NoVotes { get; set; }

        /// <summary>
        /// Number of 'absention' choices for this vote
        /// </summary>
        public int AbsentionVotes { get; set; }
        [JsonIgnore]
        public virtual ICollection<OneVote> OneVote { get; set; }

    }
}
