using Business.Configuration.Response;
using DTO.User;
using Models.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        public IEnumerable<User> GetAll();

        public CommandResponse Insert(CreateUserRequest request);
        public CommandResponse Update(UpdateUserRequest request);
        public CommandResponse Delete(User user);
    }
}
