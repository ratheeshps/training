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
        public Response<List<Account>> GetCustomerAccounts(string customerid)
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


            List<Account> result = SqlHelper.ExtecuteProcedureReturnData<List<Account>>
                ("sp_getcustaccounts",
                r => r.TranslateAccountList(), param);


            response.Data = result;
            response.Status = outStatus.Value.ToString();
            response.Message = outMessage.Value.ToString();

            return response;

        }
        public Response<List<Account>> GetAccounts()
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

              outStatus,
              outMessage
            };


            List<Account> result= SqlHelper.ExtecuteProcedureReturnData<List<Account>>
                ("sp_getaccounts", 
                r=>r.TranslateAccountList(),param);


            response.Data = result;
            response.Status =outStatus.Value.ToString();
            response.Message = outMessage.Value.ToString();

            return response;

        }

        public Response<Account> GetSingleAccount(string accountNo)
        {
            Response<Account> response = new Response<Account>();

            var outStatus = new SqlParameter("@Status", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            var outMessage = new SqlParameter("@Message", SqlDbType.NVarChar, -1)
            {
                Direction = ParameterDirection.Output
            };

            SqlParameter[] param = {
                  new SqlParameter("@accountNo",accountNo),
                  outStatus,
              outMessage
            };


            Account result = SqlHelper.ExtecuteProcedureReturnData<Account>
                ("sp_getsingleaccount",
                r => r.TranslateAsAccount(), param);


            response.Data = result;
            response.Status = outStatus.Value.ToString();
            response.Message = outMessage.Value.ToString();

            return response;
        }
    }
}
