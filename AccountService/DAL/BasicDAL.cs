using AccountService.Utilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.DAL
{
    public class BaseDAL
    {
        public BaseDAL()
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory() + "/").AddJsonFile("appsettings.json", false)
               .Build();

            SqlHelper.ConnectionString = configuration.GetSection("connectionstring").Value;
        }
    }
}
