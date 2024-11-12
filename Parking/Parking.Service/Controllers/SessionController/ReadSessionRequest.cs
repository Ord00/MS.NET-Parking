namespace Parking.Controllers.SessionController;

public class ReadSessionRequest
{
    public DateTime? EntryDate { get; set; }
    
    public DateTime? ExitDate { get; set; }
    
    public int? UserId { get; set; }
    
    public int? VehicleId { get; set; }
}