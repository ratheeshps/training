using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Models
{
    // Select AccountNumber, AccountType,AccountName,LedgerCode,CustomerID,Balance,CurrencyName from AcccountsTable
    public class Account : IAccount
    {
        [Required]
        public string AccountNumber { get; set; }
        [RegularExpression("([A-Z]*)")]
        public string AccountType { get; set; }
        [Required]
        public string AccountName { get; set; }
        public string LedgerCode { get; set; } //Current Account - 10, Saving Account -20
        // 0210 - 0239301 - 001 -0010 -000
        // Branch Code - Customer Number - BankCode - Ledger - Sub ledger
        public string CustomerID { get; set; }
        public decimal Balance { get; set; }
        public string CurrencyName { get; set; }
    }

    public interface IAccount
    {
         string AccountNumber { get; set; }
         string AccountType { get; set; }
         string AccountName { get; set; }
         string LedgerCode { get; set; } 
         string CustomerID { get; set; }
        decimal Balance { get; set; }
         string CurrencyName { get; set; }
    }
}
