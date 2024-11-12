using AutoMapper;
using Parking.BL.Users.Entities;
using Parking.BL.Users.Entities.ActionModels;
using Parking.Controllers.UserController;

namespace Parking.Mapper;

public class UserServicesProfile : Profile
{
    public UserServicesProfile()
    {
        CreateMap<ReadUserRequest, ReadUserModel>().ReverseMap();
        CreateMap<CreateUserRequest, CreateUserModel>().ReverseMap();
    }
}