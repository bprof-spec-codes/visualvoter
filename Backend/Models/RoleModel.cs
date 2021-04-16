using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    /// <summary>
    /// A model used to describe whta roles does a specific user have
    /// </summary>
   public class RoleModel
    {
        /// <summary>
        /// IdentityUser object
        /// </summary>
        public IdentityUser User { get; set; }
        /// <summary>
        /// A collection of the roles that belong to the user
        /// </summary>
        public List<string> Roles { get; set; }
    }
}
