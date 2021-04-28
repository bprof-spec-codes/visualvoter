using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class RoleSwitch
    {
        [Key]
        public int OneRoleSwitchID { get; set; }

        public string UserName { get; set; }

        public string RoleName { get; set; }
    }
}
