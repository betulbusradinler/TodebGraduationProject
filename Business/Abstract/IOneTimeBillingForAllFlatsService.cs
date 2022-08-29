using Business.Configuration.Response;
using DTO.UtilityBill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOneTimeBillingForAllFlatsService
    {
        CommandResponse Register(CreateUtilityBillRequestForAllFlats request);
    }
}
