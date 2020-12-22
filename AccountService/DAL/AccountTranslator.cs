using AccountService.Models;
using AccountService.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.DAL
{
    public static class AccountTranslator
    {
       
        public static List<Account> TranslateAccount(this SqlDataReader reader)
        {
            var list = new List<Account>();
            while (reader.Read())
            {

                list.Add(TranslateAsAccount(reader));
            }
            return list;
        }

        private static Account TranslateAsAccount(SqlDataReader reader)
        {
            if (!reader.HasRows)
                return null;
            reader.Read();
            var item = new Account();

            if (reader.IsColumnExists("AccountName"))
                item.AccountName = SqlHelper.GetNullableString(reader, "AccountName");

            if (reader.IsColumnExists("AccountNumber"))
                item.AccountNumber = SqlHelper.GetNullableString(reader, "AccountNumber");

            if (reader.IsColumnExists("AccountType"))
                item.AccountType = SqlHelper.GetNullableString(reader, "AccountType");

            if (reader.IsColumnExists("Balance"))
                item.Balance = SqlHelper.GetNullableDecimal(reader, "Balance");

            if (reader.IsColumnExists("CustomerID"))
                item.CustomerID = SqlHelper.GetNullableString(reader, "CustomerID");




            if (reader.IsColumnExists("LedgerCode"))
                item.LedgerCode = SqlHelper.GetNullableString(reader, "LedgerCode");
            if (reader.IsColumnExists("CurrencyName"))
                item.CurrencyName = SqlHelper.GetNullableString(reader, "CurrencyName");


            return item;
        }
    }
}
