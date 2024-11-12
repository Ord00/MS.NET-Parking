using AutoMapper;
using Parking.BL.Sessions.Entities;

namespace Parking.BL.Mapper;

public class SessionModelsProfile : Profile
{
    public SessionModelsProfile()
    {
        CreateMap<SessionModel, SessionResponse>().ReverseMap()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.EntryDate, y => y.MapFrom(z => z.EntryDate))
            .ForMember(x => x.ExitDate, y => y.MapFrom(z => z.ExitDate))
            .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
            .ForMember(x => x.VehicleId, y => y.MapFrom(z => z.VehicleId));
    }
}