using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
   public class RoleModel
    {
        public IdentityUser User { get; set; }
        public List<string> Roles { get; set; }
    }
}
