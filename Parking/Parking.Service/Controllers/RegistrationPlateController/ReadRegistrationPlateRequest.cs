namespace Parking.Controllers.RegistrationPlateController;

public class ReadRegistrationPlateRequest
{
    public int RegistrationNumber { get; set; }
    public string Letters { get; set; }
    public int RegionCode { get; set; }
    public string Country { get; set; }
}