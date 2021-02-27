using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Users
    {
        [Key]
        /// <summary>
        /// Unique id for each user
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Indicataes if the user is an admin or not
        /// </summary>
        public int IsAdmin { get; set; }

        /// <summary>
        /// Gets or sets if the user's title (Hallgató, hökös, szenátor stb..
        /// </summary>
        public int UserType { get; set; }

        /// <summary>
        /// Gets or sets the user's email address
        /// </summary>
        public string Email { get; set; }

        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the hashed password of the user, for login purposes. (Hashing method TBD)
        /// </summary>
        public string UserPassword { get; set; }
        [JsonIgnore]
        public virtual ICollection<OneVote> OneVote { get; set; }
    }
}
