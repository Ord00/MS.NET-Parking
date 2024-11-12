using AutoMapper;
using Parking.BL.Sessions.Entities.ActionModels;
using Parking.Controllers.SessionController;

namespace Parking.Mapper;

public class SessionServicesProfile : Profile
{
    public SessionServicesProfile()
    {
        CreateMap<ReadSessionRequest, ReadSessionModel>().ReverseMap();
        CreateMap<CreateSessionRequest, CreateSessionModel>().ReverseMap();
    }
}