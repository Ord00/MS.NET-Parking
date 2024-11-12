namespace Parking.Controllers.ZoneTariffController;

public class UpdateZoneTariffRequest
{
    public string? ZoneName { get; set; }
    public decimal? ParkingPrice { get; set; }
    
    public int? VehicleTypeId { get; set; }
}