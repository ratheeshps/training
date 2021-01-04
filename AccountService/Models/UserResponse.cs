using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Models
{
    public class UserResponse
    {
        public int UserId { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
    }
}
