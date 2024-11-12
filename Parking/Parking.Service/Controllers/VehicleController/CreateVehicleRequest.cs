namespace Parking.Controllers.VehicleController;

public class CreateVehicleRequest
{
    public string Model { get; set; }
    public string Brand { get; set; }
    public string Colour { get; set; }
    
    public int VehicleTypeId { get; set; }
    
    public int RegistrationPlateId { get; set; }
}