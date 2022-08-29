using AutoMapper;
using DTO.Chat;
using DTO.Flat;
using DTO.User;
using DTO.UtilityBill;
using DTO.UtilityBillType;
using Models.Entities;
using System.Linq;

namespace Business.Configuration.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateUserRegisterRequest, User>();
            CreateMap<UpdateUserRequest, User>();
            CreateMap<User, SearchUserResponse>();
            CreateMap<DeleteUserRequest, User>();

            CreateMap<CreateFlatRegisterRequest, Flat>();
            CreateMap<UpdateFlatRequest, Flat>();
            CreateMap<Flat, SearchFlatResponse>();
            CreateMap<DeleteFlatRequest, Flat>();

            CreateMap<CreateUtilityBillRequest, UtilityBill>();
            CreateMap<DeleteUtilityBillRequest, UtilityBill>();
            CreateMap<UpdateUtilityBillRequest, UtilityBill>();
            CreateMap<UtilityBill, SearchUtilityBillResponse>();

            CreateMap<CreateUtilityBillTypeRegisterRequest, UtilityBillType>();
            CreateMap<DeleteUtilityBillTypeRequest, UtilityBillType>();
            CreateMap<UpdateUtilityBillTypeRequest, UtilityBillType>();
            CreateMap<UtilityBillType, SearchUtilityBillTypeResponse>();


            CreateMap<CreateChatRegisterRequest, Chat>();
            CreateMap<DeleteChatRequest, Chat>();
            CreateMap<UpdateChatRequest, Chat>();
            CreateMap<Chat, SearchChatResponse>();

            CreateMap<CreateUtilityBillRequestForAllFlats, UtilityBill>();

            CreateMap<CreateUserRegisterRequest, User>().ForMember(x => x.Permissions,
              a => a.MapFrom(c => c.UserPermissions.Select(b =>
                  new UserPermission()
                  {
                      Permission = b
                  })));

        }
    }
}
