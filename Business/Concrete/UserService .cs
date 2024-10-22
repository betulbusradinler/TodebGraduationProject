﻿using AutoMapper;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private IMapper _mapper;
        private readonly IDistributedCache _distributedCache;

        public UserService(IUserRepository repository, IMapper mapper, IDistributedCache distributedCache)
        {
            _userRepository = repository;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }

        // İstenen kullanıcı silindi ama bunu ancak yönetici yapabilir
        public CommandResponse Delete(DeleteUserRequest request)
        {
            var data = _userRepository.Get(x => x.Id == request.Id); // Silinmek istenen kullanıcı kontrolünü yaptım.
            if(data == null) //Gelen data boş ise böyle bir kullanıcı yok
            {
                return new CommandResponse() 
                {
                    Message = "Böyle bir kullanıcı bulunamadı",
                    Status = false
                };
            }
            // Değilse veri tabanından silme işlemleri
            _userRepository.Delete(data);
            _userRepository.SaveChanges();

            return new CommandResponse() 
            {
                Message = "Kullanıcı silindi",
                Status = true
            };

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
            //Requestte gelen bilgilerin validation işlemleri yapılır
            var validator = new CreateUserRequestValidator();
            validator.Validate(request).ThrowIfException();

            var userPassword = request.Name + request.Surname; // Kullanıcı ilk oluşturulduğunda otomatik şifre atama


            byte[] passwordHash, passwordSalt;  // Şifre için hash ve salt oluşturuldu
            HashHelper.CreatePasswordHash(userPassword, out passwordHash, out passwordSalt);
            var user = _mapper.Map<User>(request);  // Gelen Dto dan bir tane User entity si oluşturduk passwordü boş

            user.Password = new UserPassword()  // Password newlendi
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _userRepository.Add(user);     // Kullanıcı eklendi
            _userRepository.SaveChanges(); // Veritabanına gitti


            var key = StringHelper.CreateCacheKey(user.Name, user.Id);
            var cachePermission = System.Text.Json.JsonSerializer.Serialize(request.UserPermissions);

            _distributedCache.SetString(key, cachePermission);
            return new CommandResponse()  // response çıktı
            {
                Message = "Kullanıcı başarılı şekilde kaydedildi",
                Status = true,
            };

        }

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
            var mappedEntity = _mapper.Map(request,entity);
            _userRepository.Update(mappedEntity);
            _userRepository.SaveChanges();

            return new CommandResponse
            {
                Status = true,
                Message = $"Müşteri güncellendi. Name={request.Name}"
            };
        }

    }
}
