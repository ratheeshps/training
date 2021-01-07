using AccountService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.DAL
{
    public interface IBeneficiaryDataAccess
    {
        Response<List<BeneficiaryModel>> GetBeneficiaries(string customerNo,string type);
    }
}
