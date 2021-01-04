using AccountService.Models;
using AccountService.Repostirory;
using AccountService.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.DAL
{
    public class UserAccess : BaseDAL, IUserAccess
    {
        public Response<UserResponse> GetUserAccess(UserModel user)
        {
            Response<UserResponse> response = new Response<UserResponse>();

            var customerid = new SqlParameter("@customerid", SqlDbType.NVarChar, 20);
            var username = new SqlParameter("@username", SqlDbType.NVarChar, 20);
            var password = new SqlParameter("@password", SqlDbType.NVarChar, 20);

            customerid.Value = user.CustomerID;
            username.Value = user.Username;
            password.Value = user.Password;

            var outStatus = new SqlParameter("@Status", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };


            var outMessage = new SqlParameter("@Message", SqlDbType.NVarChar, -1)
            {
                Direction = ParameterDirection.Output
            };

            SqlParameter[] param = {
                customerid,
                username,
                password,
              outStatus,
              outMessage
            };


            UserResponse result = SqlHelper.ExtecuteProcedureReturnData<UserResponse>
                ("usp_GetUserAccess",
                r => r.TranslateUserAccess(), param);


            response.Data = result;
            response.Status = outStatus.Value.ToString();
            response.Message = outMessage.Value.ToString();

            return response;
        }
    }
}
