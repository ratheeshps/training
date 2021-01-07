using AccountService.Models;
using AccountService.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.DAL
{
    public static class BeneficiaryTranslator
    {
        public static List<BeneficiaryModel> TranslateBeneficiaryList(this SqlDataReader reader)
        {
            var list = new List<BeneficiaryModel>();
            while (reader.Read())
            {
                list.Add(TranslateAsBeneficiary(reader, true));
            }
            return list;
        }

        public static BeneficiaryModel TranslateAsBeneficiary(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new BeneficiaryModel();

            if (reader.IsColumnExists("BeneficiaryAccount"))
                item.BeneficiaryAccount = SqlHelper.GetNullableString(reader, "BeneficiaryAccount");

            if (reader.IsColumnExists("AccountName"))
                item.BeneficiaryName = SqlHelper.GetNullableString(reader, "AccountName");

           
            return item;
        }
    }
}
