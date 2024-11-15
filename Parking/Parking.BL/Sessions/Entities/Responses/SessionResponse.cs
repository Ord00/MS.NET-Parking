namespace Parking.BL.Sessions.Entities.Responses;

public class SessionResponse
{
    public int Id { get; set; }
    
    public DateTime EntryDate { get; set; }
    
    public DateTime? ExitDate { get; set; }
    
    public int UserId { get; set; }
    
    public int VehicleId { get; set; }
}