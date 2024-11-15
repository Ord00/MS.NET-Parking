using AutoMapper;
using Parking.BL.Vehicles.Entities;
using Parking.BL.Vehicles.Entities.Responses;

namespace Parking.BL.Mapper;

public class VehicleModelsProfile : Profile
{
    public VehicleModelsProfile()
    {
        CreateMap<VehicleModel, VehicleResponse>().ReverseMap()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Brand, y => y.MapFrom(z => z.Brand))
            .ForMember(x => x.Model, y => y.MapFrom(z => z.Model))
            .ForMember(x => x.Colour, y => y.MapFrom(z => z.Colour))
            .ForMember(x => x.RegistrationPlateId, y => y.MapFrom(z => z.RegistrationPlateId))
            .ForMember(x => x.VehicleTypeId, y => y.MapFrom(z => z.VehicleTypeId));
    }
}