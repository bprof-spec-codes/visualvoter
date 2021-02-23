using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class OneVote
    {
        /// <summary>
        /// Unique id for each specific vote
        /// </summary>
        public string OneVoteID { get; set; }

        /// <summary>
        /// Gets or sets which voting event does this specific vote belong to.
        /// </summary>
        public string VoteID { get; set; }

        /// <summary>
        /// Gets or sets which user submitted this vote
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// (Nullable bool!)
        /// Gets or sets what this user's choice was. true = yes; false = no, NULL = absention (vagy tartózkodott, fene se tudja hogy van árgyélusul)
        /// </summary>
        public bool? Choice { get; set; }

    }
}
