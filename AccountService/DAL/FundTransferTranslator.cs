using AccountService.Models;
using AccountService.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.DAL
{
    public static class FundTransferTranslator
    {
        public static FundTransferResponse TranslateAsFTResponse(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new FundTransferResponse();

            if (reader.IsColumnExists("ReferenceNumber"))
                item.ReferenceNumber = SqlHelper.GetNullableString(reader, "ReferenceNumber");

            if (reader.IsColumnExists("ValueDate"))
                item.ValueDate = SqlHelper.GetNullableString(reader, "ValueDate");


            return item;
        }
    }
}
