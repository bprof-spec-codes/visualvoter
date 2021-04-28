using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    /// <summary>
    /// Model used to handle if a user wants a request to switch from one role to another.
    /// </summary>
    public class RoleSwitch
    {
        /// <summary>
        /// Unique id for each specific role switch request.
        /// </summary>
        [Key]
        public int OneRoleSwitchID { get; set; }

        /// <summary>
        /// Username of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Name of the role the user wants to switch into.
        /// </summary>
        public string RoleName { get; set; }
    }
}
