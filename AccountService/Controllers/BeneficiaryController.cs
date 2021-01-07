using AccountService.DAL;
using AccountService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public class BeneficiaryController : ControllerBase
    {
        [HttpPost]
        [ApiVersion("1.0")] //  api/v1/accounts
        public IActionResult Post(CustomerModel model)
        {
            BeneficiaryDataAcces bd = new BeneficiaryDataAcces();
            return Ok(bd.GetBeneficiaries(model.CustomerId,"NEFT"));
        }
    }
}

