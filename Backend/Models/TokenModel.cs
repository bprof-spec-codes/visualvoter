using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class TokenModel
    {
        public string Token { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
