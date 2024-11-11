using AutoMapper;
using Parking.BL.Users.Entities;
using Parking.BL.Users.Entities.Responses;
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