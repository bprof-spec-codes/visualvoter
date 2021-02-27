using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
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
        /// Gets or sets which user submitted this vote
        /// </summary>
        [ForeignKey("Users")]
        public int UserID { get; set; }

        /// <summary>
        /// (Nullable bool!)
        /// Gets or sets what this user's choice was. true = yes; false = no, NULL = absention (vagy tartózkodott, fene se tudja hogy van árgyélusul)
        /// </summary>
        public bool? Choice { get; set; }

        public virtual Users Users { get; set; }

        public virtual AllVotes AllVotes { get; set; }

    }
}
