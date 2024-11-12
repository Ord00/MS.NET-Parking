namespace Parking.BL.Vehicles.Entities;

public class VehicleModel
{
    public int Id { get; set; }
    
    public string Model { get; set; }
    
    public string Brand { get; set; }
    
    public string Colour { get; set; }
    
    public int VehicleTypeId { get; set; }
    
    public int RegistrationPlateId { get; set; }
}