using AccountService.DAL;
using AccountService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class FundTransferController : ControllerBase
    {
        [HttpPost]
        [ApiVersion("1.0")] //  api/v1/accounts
        public IActionResult Post(FundTransferModel model)
        {
            FundTransferDataAccess ft = new FundTransferDataAccess();
            return Ok(ft.TransferFunds(model));
        }
    }
}
