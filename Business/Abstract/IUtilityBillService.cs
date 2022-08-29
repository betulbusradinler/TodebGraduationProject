using Business.Configuration.Response;
using DTO.UtilityBill;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUtilityBillService
    {
        CommandResponse Register(CreateUtilityBillRequest request);
       // CommandResponse PostInvoiceToAllFlats(CreateUtilityBillRequest request);
        IEnumerable<SearchUtilityBillResponse> GetAll();
        CommandResponse Update(UpdateUtilityBillRequest request);
        CommandResponse Delete(DeleteUtilityBillRequest request);
    }
    
}
