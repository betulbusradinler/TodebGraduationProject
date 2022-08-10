using AutoMapper;
using Business.Abstract;
using Business.Configuration.Extensions;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation;
using DAL.Abstract;
using DTO.User;
using Models.Entities;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;  //
        private IMapper _mapper;
        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public CommandResponse Insert(CreateUserRequest request)
        {
            // Requestte gelen bilgilerin validation işlemleri yapılır
            var validator = new CreateUserRequestValidator();
            validator.Validate(request).ThrowIfException();

            var entity = _mapper.Map<User>(request);
            _repository.Insert(entity);

            return new CommandResponse
            {
                Status = true,
                Message = $"Müşteri eklendi. Id={request.Name}"
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

        public CommandResponse Update(UpdateUserRequest request)
        {
            var validator = new UpdateUserRequestValidator();
            validator.Validate(request).ThrowIfException();  // validate işlemi önce yapıldı çünkü gelen Id 0 dan büyük mü kontrolünü sağlaması için.

            var entity = _repository.Get(request.Id);  //Gelen Id veritabanında var mı onu kontrol ediyoruz. Veritabanından gelen Entity
            if(entity == null)
            {
                return new CommandResponse
                {
                    Status = false,
                    Message = "Böyle bir kullanıcı bulunamadı"
                };
            }
            var mappedEntity = _mapper.Map<User>(request);
            _repository.Update(mappedEntity);

            return new CommandResponse
            {
                Status = true,
                Message = $"Müşteri güncellendi. Name={request.Name}"
            };
        }
    }
}
