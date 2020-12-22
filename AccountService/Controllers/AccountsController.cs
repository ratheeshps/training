using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountService.Models;
using AccountService.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Web.Http;

namespace AccountService.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    
    public class AccountsController : ControllerBase
    {
     
        [Microsoft.AspNetCore.Mvc.ApiVersion("1.0")] //  api/v1/accounts
        ///
        /// Get Accounts list
        ///
        public IActionResult Get()
        {
            // 1. ADO.NET - most performing method
            // 2. Dapper - high performance and easily code
            // 3. EntityFramework - easily code but heavy, low performance 

            // if you are developer without much db knowledge - entrity framework is the best.


            AccountDataAccess accountDataAccess = new AccountDataAccess();
            
            return Ok(accountDataAccess.GetAccounts("123"));
        }

       

        
    }
}
