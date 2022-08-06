using Business.Abstract;
using Business.Configuration.Response;
using DAL.Abstract;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public CommandResponse Add(User user)
        {
            _repository.Add(user);
            return new CommandResponse
            {
                Status = true,
                Message = $"Müşteri eklendi. Id={user.Id}"
            };
        }

        public CommandResponse Delete(User user)
        {

            _repository.Delete(user);
            return new CommandResponse
            {
                Status = true,
                Message = $"Müşteri eklendi. Id={user.Id}"
            };
        }

        public IEnumerable<User> GetAll()
        {
            // User bilgilerini repository içerisinden çağırmış olduğum GetAll() metodu ile alıyordum
            return _repository.GetAll();
        }

        public CommandResponse Update(User user)
        {
            _repository.Update(user);
            return new CommandResponse
            {
                Status = true,
                Message = $"Müşteri eklendi. Id={user.Id}"
            };
        }
    }
}
