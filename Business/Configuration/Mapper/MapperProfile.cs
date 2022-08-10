using AutoMapper;
using DTO.User;
using Models.Entities;

namespace Business.Configuration.Mapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();
        }
    }
}
