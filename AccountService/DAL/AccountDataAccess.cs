using AccountService.DAL;
using AccountService.Models;
using AccountService.Repostirory;
using AccountService.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService
{
    public class AccountDataAccess : BaseDAL, IAccountDataAccess
    {
        public Response<Account> GetAccountDetails()
        {

            Response<Account> response = new Response<Account>();

            return response;
        }

        public Response<List<Account>> GetAccounts(string customerid)
        {
            Response<List<Account>> response = new Response<List<Account>>();

            var outStatus = new SqlParameter("@Status", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            var outMessage = new SqlParameter("@Message", SqlDbType.NVarChar, -1)
            {
                Direction = ParameterDirection.Output
            };

            SqlParameter[] param = {
                new SqlParameter("@customerid",customerid),
              outStatus,
              outMessage
            };


            List<Account> result= SqlHelper.ExtecuteProcedureReturnData<List<Account>>("sp_getaccounts", 
                r=>r.TranslateAccount(),param);


            response.Data = result;
            response.Status =outStatus.Value.ToString();
            response.Message = outMessage.Value.ToString();

            return response;

        }



    }
}
