using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class UserType
    {
        [Key]
        public int UserTypeID { get; set; } //auto generated
        public string UserTypeName { get; set; }
        public virtual ICollection<Users> Users { get; set; }
        public virtual ICollection<VotingRight> VotingRight { get; set; }
    }
}
