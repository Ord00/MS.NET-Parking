using Parking.BL.Vehicles.Entities;
using Parking.BL.Vehicles.Entities.ActionModels;

namespace Parking.BL.Vehicles.Manager;

public interface IVehicleManager
{
    VehicleModel CreateVehicle(CreateVehicleModel model);
    
    VehicleModel UpdateVehicle(int id, UpdateVehicleModel model);
    
    void DeleteVehicle(int id);
}