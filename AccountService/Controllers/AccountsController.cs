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
        public IActionResult Get()
        {
            // Calling a method to calculate account balance - Bank account balance
            return Ok("Accounts Get Method");
        }

        [HttpGet("account")]
        [Microsoft.AspNetCore.Mvc.ApiVersion("2.0")] // api/v2/account
        public IActionResult Get2()
        {
            //
            // Calling a method to calculate account balance - with Bank, Card, Loan balance

            return Ok("Accounts Get Method");
        }


        [HttpPost]
        public IActionResult Post([FromForm]  Account model)
        {
            if (ModelState.IsValid)
            {
                return Ok(model);

            }
            else
            {
                //Logging
                if (!string.IsNullOrEmpty(model.AccountName))
                {
                    return BadRequest("No account name given");
                }
                else
                    return BadRequest();
            }
        }

        [HttpPost("accountpost")]
        public IActionResult PostAccount()
        {
            return Ok();
        }

        
    }
}
