using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Models
{
    public class Account : IAccount
    {
        public string AccountName { get; set; }
        [RegularExpression("([A-Z]*)")]
        public string AccountType { get; set; }
        public string IDType { get; set; }
        public string CustomerId { get; set; }
    }
}
