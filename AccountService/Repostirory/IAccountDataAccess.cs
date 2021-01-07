using AccountService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Repostirory
{
    public interface IAccountDataAccess
    {
        Response<Account> GetSingleAccount(string accountNo);
        Response<List<Account>> GetCustomerAccounts(string customerid);
        Response<List<Account>> GetAccounts();
        Response<Account> GetAccountDetails();
    }
}
