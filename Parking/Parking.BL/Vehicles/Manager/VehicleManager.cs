using AutoMapper;
using Parking.BL.Vehicles.Entities;
using Parking.BL.Vehicles.Entities.ActionModels;
using Parking.DataAccess;
using Parking.DataAccess.Entities;

namespace Parking.BL.Vehicles.Manager;

public class VehicleManager(IRepository<VehicleEntity> vehiclesRepository, IMapper mapper) : IVehicleManager
{
    public VehicleModel CreateUser(CreateVehicleModel model)
    {
        var entity = mapper.Map<VehicleEntity>(model);
        entity = vehiclesRepository.Save(entity);
        return mapper.Map<VehicleModel>(entity);
    }

    public void DeleteUser(int id)
    {
        var entity = vehiclesRepository.GetById(id);

        if (entity == null)
        {
            throw new KeyNotFoundException();
        }

        vehiclesRepository.Delete(entity);

    }

    public VehicleModel UpdateUser(int id, UpdateVehicleModel model)
    {
        var entity = vehiclesRepository.GetById(id);
            
        if (entity == null)
        {
            throw new KeyNotFoundException();
        }
            
        entity = vehiclesRepository.Save(entity);
        return mapper.Map<VehicleModel>(entity);
    }
}