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
        public int UserTypeNumber { get; set; }
        public string UserTypeName { get; set; }
    }
}
