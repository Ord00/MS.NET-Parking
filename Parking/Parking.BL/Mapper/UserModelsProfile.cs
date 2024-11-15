using AutoMapper;
using Parking.BL.Users.Entities;
using Parking.BL.Users.Entities.Responses;

namespace Parking.BL.Mapper;

public class UserModelsProfile : Profile
{
    public UserModelsProfile()
    {
        CreateMap<UserModel, UserResponse>().ReverseMap()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
            .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
            .ForMember(x => x.Birthday, y => y.MapFrom(z => z.Birthday))
            .ForMember(x => x.Patronymic, y => y.MapFrom(z => z.Patronymic))
            .ForMember(x => x.Login, y => y.MapFrom(z => z.Login))
            .ForMember(x => x.UserRole, y => y.MapFrom(z => z.UserRole));
    }
}