using AccountService.Models;
using AccountService.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.DAL
{
    public class FundTransferDataAccess : BaseDAL, IFundTransferDataAccess
    {
        public Response<FundTransferResponse> TransferFunds(FundTransferModel model)
        {
            Response<FundTransferResponse> response = new Response<FundTransferResponse>();

            var outStatus = new SqlParameter("@Status", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            var outMessage = new SqlParameter("@Message", SqlDbType.NVarChar, -1)
            {
                Direction = ParameterDirection.Output
            };

            SqlParameter[] param = {
                  new SqlParameter("@customerid",model.CustomerId),
                  new SqlParameter("@fromAccount",model.FromAccount),
                  new SqlParameter("@toaccount",model.ToAccount),
                  new SqlParameter("@amount",model.Amount),
                  new SqlParameter("@remarks",model.Remarks),
              outStatus,
              outMessage
            };


            FundTransferResponse result = SqlHelper.ExtecuteProcedureReturnData<FundTransferResponse>
                ("sp_TranferFunds",
                r => r.TranslateAsFTResponse(), param);


            response.Data = result;
            response.Status = outStatus.Value.ToString();
            response.Message = outMessage.Value.ToString();

            return response;
        }
    }
}
