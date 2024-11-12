namespace Parking.BL.Vehicles.Entities.ActionModels;

public class CreateVehicleModel
{
    public string Model { get; set; }
    public string Brand { get; set; }
    public string Colour { get; set; }
    
    public int VehicleTypeId { get; set; }
    
    public int RegistrationPlateId { get; set; }
}