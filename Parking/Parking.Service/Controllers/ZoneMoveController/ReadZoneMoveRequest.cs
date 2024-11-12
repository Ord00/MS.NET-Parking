namespace Parking.Controllers.ZoneMoveController;

public class ReadZoneMoveRequest
{
    public DateTime? EntryDate { get; set; }
    public DateTime? ExitDate { get; set; }
    
    public int? SessionId { get; set; }
    
    public int? ZoneTariffId { get; set; }
}