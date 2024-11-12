using Parking.BL.Vehicles.Entities;
using Parking.BL.Vehicles.Entities.ActionModels;

namespace Parking.BL.Vehicles.Provider;

public interface IVehicleProvider
{
    IEnumerable<VehicleModel> GetVehicles(ReadVehicleModel filter);
    
    VehicleModel GetVehicleInfo(int id);
}