using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Models
{
    public class Audience
    {
        public string Secret { get; set; }
        public string Iss { get; set; }
        public string Aud { get; set; }
        public string Aud1 { get; set; }
    }
    public class AppSettings
    {
        public string ApiAuthKey { get; set; }
        public string ApiSecretSigningKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public long TokenExpiry { get; set; } // In minutes
    }
}
