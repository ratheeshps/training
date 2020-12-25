using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace AccountService.Handler
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions>  options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) :base(options, logger, encoder, clock)
        {

        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {

            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Authorization header not found");

            var headers = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);

            var bytes = Convert.FromBase64String(headers.Parameter);

            string cred = Encoding.UTF8.GetString(bytes);

            // Split it
            // Compare it with db

            // var user =db.users.firstordefault(x=>x.email==cred[0]);
            //if(user !=null)
            // AddClaim - token.AddClaim("customerID", user.Customer);
            // return AutheitcateResult.SUccess


            // if success AuthenticateResult.Success("Success")

            return AuthenticateResult.Fail("Not yet implemented");
        }
    }
}
