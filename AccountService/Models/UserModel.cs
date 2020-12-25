using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Models
{
    public class UserModel
    {
        public string CustomerID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AuthResponse
    {
        public string Token { get; set; }
        public int Expiry { get; set; }
    }
}
