using AutoMapper;
using Parking.BL.Users.Entities;
using Parking.BL.Vehicles.Entities;
using Parking.BL.Vehicles.Entities.ActionModels;
using Parking.DataAccess;
using Parking.DataAccess.Entities;

namespace Parking.BL.Vehicles.Provider;

public class VehicleProvider(IRepository<VehicleEntity> vehicleRepository, IMapper mapper) : IVehicleProvider
{
    public IEnumerable<VehicleModel> GetVehicles(ReadVehicleModel? filter = null)
    {
        var brand = filter?.Brand;
        var colour = filter?.Colour;
        var model = filter?.Model;
        var vehicleTypeId = filter?.VehicleTypeId;
        var registrationPlateId = filter?.RegistrationPlateId;

        var vehicles = vehicleRepository.GetAll(x =>
            (brand == null || x.Brand == brand) &&
            (colour == null || x.Colour.Contains(colour)) &&
            (model == null || x.Model.Contains(model)) &&
            (vehicleTypeId == null || x.VehicleTypeId == vehicleTypeId) &&
            (registrationPlateId == null || x.RegistrationPlateId == registrationPlateId)
        );
        
        return mapper.Map<IEnumerable<VehicleModel>>(vehicles);
    }

    public VehicleModel GetVehicleInfo(int id)
    {
        var entity = vehicleRepository.GetById(id);
        
        if (entity == null)
        {
            throw new KeyNotFoundException();
        }

        return mapper.Map<VehicleModel>(entity);
    }
}