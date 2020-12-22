using AccountService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Repostirory
{
    public interface IAccountDataAccess
    {
        Response<List<Account>> GetAccounts(string customerid);
        Response<Account> GetAccountDetails();
    }
}
