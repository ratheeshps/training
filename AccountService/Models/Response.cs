using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Models
{
    public class Response<T>
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
    /*
  
     { "status":"1", "message":"Data fectched successfully", Data:{Account1, Account2,} } 
  { "status":"0", "message":"No data found", Data:{[]} }

    { "status":"-99", "message":"SQL connection exception", Data:{[]} }
     */
}
