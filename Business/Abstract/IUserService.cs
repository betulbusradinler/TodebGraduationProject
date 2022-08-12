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


        //public CommandResponse Insert(CreateUserRegisterRequest request);
        //public CommandResponse Update(UpdateUserRequest request);
        //public CommandResponse Delete(User user);
    }
}
