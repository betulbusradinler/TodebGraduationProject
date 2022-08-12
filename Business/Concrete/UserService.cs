using AutoMapper;
using Business.Abstract;
using Business.Configuration.Auth;
using Business.Configuration.Extensions;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation;
using DAL.Abstract;
using DTO.User;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;


namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private IMapper _mapper;
        public UserService(IUserRepository repository, IMapper mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
        }

        // Tüm kullanıcılar listelendi

        public IEnumerable<SearchUserResponse> GetAll()
        {
            var data = _userRepository.GetAll();
            var mappedData = data.Select(x => _mapper.Map<SearchUserResponse>(x)).ToList();
            return mappedData;

        }

        // Kullanıcı kaydı yapıldı 
        public CommandResponse Register(CreateUserRegisterRequest request)
        {
            // validasyonlar yazıldı
            //Requestte gelen bilgilerin validation işlemleri yapılır

            var validator = new CreateUserRequestValidator();
            validator.Validate(request).ThrowIfException();

            //var entity = _mapper.Map<User>(request);
            //_userRepository.Add(entity);

            byte[] passwordHash, passwordSalt;  // Şifre için hash ve salt oluşturuldu
            HashHelper.CreatePasswordHash(request.UserPassword, out passwordHash, out passwordSalt);
            var user = _mapper.Map<User>(request);  // Gelen Dto dan bir tane User entity si oluşturduk passwordü boş

            user.Password = new UserPassword()  // Password newlendi
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _userRepository.Add(user);     // Kullanıcı eklendi
            _userRepository.SaveChanges(); // Veritabanına gitti

            return new CommandResponse()  // response çıktı
            {
                Message = "Kullanıcı başarılı şekilde kaydedildi",
                Status = true
            };

        }

        //    private IMapper _mapper;
        //    public UserService(IUserRepository repository, IMapper mapper)
        //    {
        //        _repository = repository;
        //        _mapper = mapper;
        //    }
        //    public CommandResponse Insert(CreateUserRegisterRequest request)
        //    {
        //        Requestte gelen bilgilerin validation işlemleri yapılır
        //        var validator = new CreateUserRequestValidator();
        //        validator.Validate(request).ThrowIfException();

        //        var entity = _mapper.Map<User>(request);
        //        _repository.Add(entity);

        //        return new CommandResponse
        //        {
        //            Status = true,
        //            Message = $"Müşteri eklendi. Id={request.Name}"
        //        };
        //    }

        //    public CommandResponse Delete(User user)
        //    {

        //        _repository.Delete(user);
        //        return new CommandResponse
        //        {
        //            Status = true,
        //            Message = $"Müşteri eklendi. Id={user.Id}"
        //        };
        //    }

        //    public IEnumerable<User> GetAll()
        //    {
        //        User bilgilerini repository içerisinden çağırmış olduğum GetAll() metodu ile alıyordum
        //        return _repository.GetAll();
        //    }

        // Kullanıcı güncellendi
        public CommandResponse Update(UpdateUserRequest request)
        {
            var validator = new UpdateUserRequestValidator();
            validator.Validate(request).ThrowIfException();  // validate işlemi önce yapıldı çünkü gelen Id 0 dan büyük mü kontrolünü sağlaması için.

            var entity = _userRepository.Get(x => x.Id == request.Id);  //Gelen Id veritabanında var mı onu kontrol ediyoruz. Veritabanından gelen Entity
            if (entity == null)
            {
                return new CommandResponse
                {
                    Status = false,
                    Message = "Böyle bir kullanıcı bulunamadı"
                };
            }
            var mappedEntity = _mapper.Map<User>(request);
            _userRepository.Update(mappedEntity);

            return new CommandResponse
            {
                Status = true,
                Message = $"Müşteri güncellendi. Name={request.Name}"
            };
        }

        //public CommandResponse Delete(Dele)

    }
}
