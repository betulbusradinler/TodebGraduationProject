using Business.Configuration.Response;
using DTO.Flat;
using DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
