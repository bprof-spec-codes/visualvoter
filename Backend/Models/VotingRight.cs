using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Models
{
    public class VotingRight
    {
        [Key]
        public int VRId { get; set; }
        [ForeignKey("Allvotes")]
        public int VoteID { get; set; }
        [ForeignKey("UserType")]
        public int UserTypeID { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserType> UserType { get; set; }
        [JsonIgnore]
        public virtual ICollection<AllVotes> AllVotes { get; set; }
    }
}
