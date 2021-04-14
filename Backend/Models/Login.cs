using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    /// <summary>
    /// Model used during user logins
    /// </summary>
    public class Login
    {
        /// <summary>
        /// The email address of the user
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password of the user
        /// </summary>
        public string Password { get; set; }
    }
}
