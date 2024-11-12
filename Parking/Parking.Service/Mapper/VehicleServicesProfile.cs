using AutoMapper;
using Parking.BL.Vehicles.Entities.ActionModels;
using Parking.Controllers.VehicleController;

namespace Parking.Mapper;

public class VehicleServicesProfile : Profile
{
    public VehicleServicesProfile()
    {
        CreateMap<ReadVehicleRequest, ReadVehicleModel>().ReverseMap();
        CreateMap<CreateVehicleRequest, CreateVehicleModel>().ReverseMap();
    }
}