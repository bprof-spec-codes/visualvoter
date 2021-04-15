using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Models
{
    /// <summary>
    /// Model outlining the structure of a OneVote object
    /// </summary>
    public class OneVote
    {
        /// <summary>
        /// Unique id for each specific vote
        /// </summary>
        /// 
        [Key]
        public int OneVoteID { get; set; }

        /// <summary>
        /// Gets or sets which voting event does this specific vote belong to.
        /// </summary>
        [ForeignKey("AllVotes")]
        public int VoteID { get; set; }

        /// <summary>
        /// Marks which vote group does this specific vote belongs to
        /// </summary>
        public string voteGroup { get; set; }

        /// <summary>
        /// Email address of the user who submitted the vote.
        /// </summary>
        public string submitterName { get; set; }

        /// <summary>
        /// (Nullable bool!)
        /// Gets or sets what this user's choice was. true = yes; false = no, NULL = absention (vagy tartózkodott, fene se tudja hogy van árgyélusul)
        /// </summary>
        public int Choice { get; set; }
        /// <summary>
        /// Virtual EF related prop, containing the allVotes associated with this OneVote
        /// </summary>
        [JsonIgnore]
        public virtual AllVotes AllVotes { get; set; }

    }
}
