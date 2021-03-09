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
        [ForeignKey("Users")]
        public int UserType { get; set; }
        [JsonIgnore]
        public virtual Users Users { get; set; }
        [JsonIgnore]
        public virtual AllVotes AllVotes { get; set; }

    }
}
