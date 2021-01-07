using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Models
{
    public class FundTransferModel
    {
        public string CustomerId { get; set; }
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
    }
}
