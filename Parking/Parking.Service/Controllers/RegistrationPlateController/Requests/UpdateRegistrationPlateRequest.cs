namespace Parking.Controllers.RegistrationPlateController;

public class UpdateRegistrationPlateRequest
{
    public int? RegistrationNumber { get; set; }
    public string? Letters { get; set; }
    public int? RegionCode { get; set; }
    public string? Country { get; set; }
}