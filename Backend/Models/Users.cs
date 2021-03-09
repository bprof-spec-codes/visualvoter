using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("UserType")]
        public UserType UserType { get; set; }

        /// <summary>
        /// Gets or sets the user's email address
        /// </summary>
        public string Email { get; set; }

        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the hashed password of the user, for login purposes. (Hashing method TBD)
        /// </summary>
        [JsonIgnore]
        public string UserPassword { get; set; }
        [JsonIgnore]
        public virtual ICollection<OneVote> OneVote { get; set; }

        //[JsonIgnore]
        //public string Token { get; set; }

        //public DateTime TokenDate { get; set; }
    }
}
