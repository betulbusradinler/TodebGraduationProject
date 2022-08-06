using Business.Configuration.Response;
using Models.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        public IEnumerable<User> GetAll();

        public CommandResponse Add(User user);
        public CommandResponse Update(User user);
        public CommandResponse Delete(User user);
    }
}
