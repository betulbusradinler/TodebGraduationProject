using AutoMapper;
using DTO.User;
using Models.Entities;

namespace Business.Configuration.Mapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateUserRegisterRequest, User>();
            CreateMap<UpdateUserRequest, User>();
            CreateMap<User,SearchUserResponse>();
            CreateMap<User, DeleteUserRequest>();

        }
    }
}
