using Business.Configuration.Response;
using DTO.UtilityBillType;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUtilityBillTypeService
    {
        CommandResponse Register(CreateUtilityBillTypeRegisterRequest request);
        IEnumerable<SearchUtilityBillTypeResponse> GetAll();
        CommandResponse Update(UpdateUtilityBillTypeRequest request);
        CommandResponse Delete(DeleteUtilityBillTypeRequest request);
    }
}
