using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    /// <summary>
    /// A model used during the login process, containing the token granted after a successful login, and it's expiration date
    /// </summary>
    public class TokenModel
    {
        /// <summary>
        /// JWT token granted to the user
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Expiration date of the token
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Indicates if the logged in user is admin or not. 
        /// </summary>
        public bool isAdmin { get; set; }

        /// <summary>
        /// Indicates if the logged in user is admin or not. 
        /// </summary>
        public bool isEditor { get; set; }
    }
}
