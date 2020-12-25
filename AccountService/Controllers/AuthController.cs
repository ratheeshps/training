using AccountService.Models;
using AccountService.Services;
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
    public class AuthController : ControllerBase
    {
       // private readonly ITokenService _tokenService;
        private IOptions<Audience> _settings;
        private readonly ILogger<AuthController> logger;
        public AuthController(ILogger<AuthController> logger,
          //  ITokenService tokenService, 
             IOptions<Audience> settings)
        {
            this._settings = settings;
            //_tokenService = tokenService;
            this.logger = logger;
        }

        [HttpPost]
        public IActionResult Post(UserModel model)
        {
            Response<AuthResponse> response = new Response<AuthResponse>();
            if (ModelState.IsValid)
            {

                // Call database to validate this model
                //if (valid)

                var now = DateTime.UtcNow;
                var claims = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, model.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64),
                    new Claim("CustomerID",model.CustomerID),
                };

                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_settings.Value.Secret));

                //var tokenValidationParameters = new TokenValidationParameters
                //{
                //    ValidateIssuerSigningKey = true,
                //    IssuerSigningKey = signingKey,
                //    ValidateIssuer = true,
                //    ValidIssuer = _settings.Value.Iss,
                //    ValidateAudience = true,
                //    ValidAudience = _settings.Value.Aud,
                //    ValidateLifetime = true,
                //    ClockSkew = TimeSpan.Zero,
                //    RequireExpirationTime = true,

                //};

                var jwt = new JwtSecurityToken(
                    issuer: _settings.Value.Iss,
                    audience: _settings.Value.Aud,
                    claims: claims,
                    notBefore: now,
                    expires: now.Add(TimeSpan.FromMinutes(1)),
                    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                var responseJson = new
                {
                    access_token = encodedJwt,
                    expires_in = (int)TimeSpan.FromMinutes(1).TotalSeconds
                };

                AuthResponse authResponse = new AuthResponse();
                authResponse.Token = responseJson.access_token;
                authResponse.Expiry = responseJson.expires_in;

                response.Status = "1";
                response.Message = "success";
                response.Data = authResponse;
            }

            return Ok(response);
        }
    }
}
