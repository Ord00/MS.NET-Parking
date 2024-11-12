using Parking.BL.Vehicles.Entities;
using Parking.BL.Vehicles.Entities.ActionModels;

namespace Parking.BL.Vehicles.Manager;

public interface IVehicleManager
{
    VehicleModel CreateUser(CreateVehicleModel model);
    
    VehicleModel UpdateUser(int id, UpdateVehicleModel model);
    
    void DeleteUser(int id);
}