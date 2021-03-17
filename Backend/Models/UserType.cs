using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Models
{
    public class UserType
    {
        [Key]
        public int UserTypeID { get; set; } //auto generated
        public string UserTypeName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Users> Users { get; set; }
        [JsonIgnore]
        public virtual ICollection<VotingRight> VotingRight { get; set; }
    }
}
