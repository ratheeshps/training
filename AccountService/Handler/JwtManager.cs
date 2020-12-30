using AccountService.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Handler
{
    public class JwtManager : IJwtManager
    {

        private IDictionary<string, string> userStore = new Dictionary<string, string>
        {
            {"ratheesh","pass1" },
            {"ratheesh1","pass2" },
            {"ratheesh2","pass3" },
        };


        private readonly IOptions<Audience> audOptions;
        public JwtManager(IOptions<Audience> audience)
        {
            this.audOptions = audience;
        }

        public string Authenticate(string uname, string pwd)
        {
            if (!userStore.Any(x => x.Key == uname && x.Value == pwd))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.ASCII.GetBytes(audOptions.Value.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                new Claim(ClaimTypes.Name,uname)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Audience = audOptions.Value.Aud,
                Issuer = audOptions.Value.Iss,
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
