using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Models
{
    public class FundTransferModel
    {
        public List<Account> OwnAccountList { get; set; }
        public List<Account> BeneficiaryAccountList { get; set; }
        public string OwnAccountNumber { get; set; }
        public string BeneficiaryAccountNumber { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
    }
}
