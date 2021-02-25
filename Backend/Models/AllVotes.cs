﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class AllVotes
    {
        /// <summary>
        /// Unique id for this voting "session"
        /// </summary>
        public string VoteID { get; set; }

        /// <summary>
        /// User readable name of the vote
        /// </summary>
        public string VoteName { get; set; }

        /// <summary>
        /// When will the current vote expire
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Used to check if this specific vote is still active
        /// </summary>
        public bool isClosed { get; set; }

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

    }
}