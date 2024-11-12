namespace Parking.BL.Vehicles.Entities.ActionModels;

public class ReadVehicleModel
{
    public string? Model { get; set; }
    public string? Brand { get; set; }
    public string? Colour { get; set; }
    
    public int? VehicleTypeId { get; set; }
    
    public int? RegistrationPlateId { get; set; }
}