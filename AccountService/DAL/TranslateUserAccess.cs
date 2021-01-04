using AccountService.Models;
using AccountService.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.DAL
{
    public static class UserAccessTranslator
    {
        public static UserResponse TranslateUserAccess(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new UserResponse();

            if (reader.IsColumnExists("CustomerName"))
                item.CustomerName = SqlHelper.GetNullableString(reader, "CustomerName");

            if (reader.IsColumnExists("MobileNumber"))
                item.MobileNumber = SqlHelper.GetNullableString(reader, "MobileNumber");

            if (reader.IsColumnExists("UserId"))
                item.UserId = SqlHelper.GetNullableInt32(reader, "UserId");

         
            return item;
        }
    }
}
