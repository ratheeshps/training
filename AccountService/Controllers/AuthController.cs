using AccountService.Handler;
using AccountService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IJwtManager manager;
        public AuthController(IJwtManager jWTManager)
        {
            manager = jWTManager;
        }
       //// private readonly ITokenService _tokenService;
       // private IOptions<Audience> _settings;
       // private readonly ILogger<AuthController> logger;
       // public AuthController(ILogger<AuthController> logger,
       //   //  ITokenService tokenService, 
       //      IOptions<Audience> settings)
       // {
       //     this._settings = settings;
       //     //_tokenService = tokenService;
       //     this.logger = logger;
       // }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post(UserModel model)
        {
           var token= manager.Authenticate(model.Username, model.Password);
            if (!string.IsNullOrEmpty(token))
                return Ok(token);
            else
            return Unauthorized();
        }
    }
}
