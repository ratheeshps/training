using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AccountService.Services
{
    public class TokenService : ITokenService
    {
        string ITokenService.GenerateAccessToken(IEnumerable<Claim> claims)
        {
            throw new NotImplementedException();
        }
    }
}
