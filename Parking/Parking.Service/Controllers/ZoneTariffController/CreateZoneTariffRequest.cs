namespace Parking.Controllers.ZoneTariffController;

public class CreateZoneTariffRequest
{
    public string ZoneName { get; set; }
    public decimal? ParkingPrice { get; set; }
    
    public int VehicleTypeId { get; set; }
}