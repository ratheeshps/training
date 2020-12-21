using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Models
{
    public class TransactionModel
    {
        public string Date { get; set; }
        public string ValueDate { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public string TransactionType { get; set; }
        public string BeneficiaryAccount { get; set; }
    }
}
