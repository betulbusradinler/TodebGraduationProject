using Business.Configuration.Response;
using DTO.Flat;
using DTO.User;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IFlatService
    {
        CommandResponse Register(CreateFlatRegisterRequest request);
        IEnumerable<SearchFlatResponse> GetAll();
        CommandResponse Update(UpdateFlatRequest request);
        CommandResponse Delete(DeleteFlatRequest request);
    }
}
