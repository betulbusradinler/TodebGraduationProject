using AutoMapper;
using Business.Abstract;
using Business.Configuration.Auth;
using Business.Configuration.Extensions;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation.UserValidation;
using Bussines.Configuration.Helper;
using DAL.Abstract;
using DTO.User;
using Microsoft.Extensions.Caching.Distributed;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;


namespace Business.Concrete
{
    public class UserPasswordService : IUserPasswordService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserPasswordRepository _userPasswordRepository;
        private IMapper _mapper;

        public UserPasswordService(IUserRepository repository, IMapper mapper, IUserPasswordRepository userPasswordRepository)
        {
            _userRepository = repository;
            _mapper = mapper;
            _userPasswordRepository = userPasswordRepository;
        }

        public CommandResponse UpdateUserPassword(UpdateUserPasswordRegisterRequest request)
        {
            var validator = new UpdateUserPasswordRequestValidator();
            validator.Validate(request).ThrowIfException();
            var user = _userRepository.Get(x => x.Id == request.UserId);

            var userpass = _userPasswordRepository.Get(x => x.UserId == request.UserId);  //Gelen Id veritabanında var mı onu kontrol ediyoruz. Veritabanından gelen Entity
            if (userpass == null || user == null)
            {
                return new CommandResponse
                {
                    Status = false,
                    Message = "Böyle bir kullanıcı bulunamadı"
                };
            }

            byte[] passwordHash, passwordSalt;
            HashHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
          
            var userpass2 = _mapper.Map(request, userpass);
            userpass2.PasswordHash = passwordHash;
            userpass2.PasswordSalt = passwordSalt;

            user.Password = new UserPassword()
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _userPasswordRepository.UpdateUserPassword(userpass2);
            _userPasswordRepository.SaveChanges();
            return new CommandResponse
            {
                Status = true,
                Message = $"Müşteri güncellendi. Numara={request.UserId}"
            };
        }
    }
}
