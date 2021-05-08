using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    /// <summary>
    /// Model outlining the structure of an AllVotes object
    /// </summary>
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
        /// User is only allowed to participate in this specific vote, if it has the role found here associated with it
        /// </summary>
        public string RequiredRole { get; set; }
        /// <summary>
        /// Number of 'absention' choices for this vote
        /// </summary>
        public int AbsentionVotes { get; set; }
        /// <summary>
        /// Virtal, EF related prop containing all the associated votes (OneVotes)
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<OneVote> OneVote { get; set; }

        /// <summary>
        /// Identifies which voting group does this current vote belongs to.
        /// </summary>
        public string voteGroup { get; set; }
    }
}
