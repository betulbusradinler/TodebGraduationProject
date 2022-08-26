using Business.Configuration.Response;
using DTO.User;
using Models.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        CommandResponse Register(CreateUserRegisterRequest request);
        IEnumerable<SearchUserResponse> GetAll();
        CommandResponse Update(UpdateUserRequest request);
        CommandResponse Delete(DeleteUserRequest request);

    }
}
