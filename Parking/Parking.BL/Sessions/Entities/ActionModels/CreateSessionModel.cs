namespace Parking.BL.Sessions.Entities.ActionModels;

public class CreateSessionModel
{
    public DateTime EntryDate { get; set; }
    
    public DateTime? ExitDate { get; set; }
    
    public int UserId { get; set; }
    
    public int VehicleId { get; set; }
}