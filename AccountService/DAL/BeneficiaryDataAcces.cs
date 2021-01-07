using AccountService.Models;
using AccountService.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AccountService.DAL;

namespace AccountService.DAL
{
    public class BeneficiaryDataAcces : BaseDAL, IBeneficiaryDataAccess
    {
        public Response<List<BeneficiaryModel>> GetBeneficiaries(string customerid,string type)
        {
            Response<List<BeneficiaryModel>> response = new Response<List<BeneficiaryModel>>();

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
                  new SqlParameter("@Type",type),
              outStatus,
              outMessage
            };


            List<BeneficiaryModel> result = SqlHelper.ExtecuteProcedureReturnData<List<BeneficiaryModel>>
                ("sp_GetBeneficiaries",
                r => r.TranslateBeneficiaryList(), param);


            response.Data = result;
            response.Status = outStatus.Value.ToString();
            response.Message = outMessage.Value.ToString();

            return response;

        }
    }
}
