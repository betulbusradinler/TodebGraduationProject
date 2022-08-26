using AutoMapper;
using DTO.Flat;
using DTO.User;
using DTO.UtilityBill;
using DTO.UtilityBillType;
using Models.Entities;

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
        }
    }
}
