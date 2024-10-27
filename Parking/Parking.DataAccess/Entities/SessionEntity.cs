using System.ComponentModel.DataAnnotations.Schema;

namespace Parking.DataAccess.Entities;

[Table("Session")]
public class SessionEntity : BaseEntity
{
    public DateTime EntryDate { get; set; }
    public DateTime? ExitDate { get; set; }
    
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    
    public int VehicleId { get; set; }
    public VehicleEntity Vehicle { get; set; }
    
    public virtual ICollection<ZoneMoveEntity> ZoneMoves { get; set; }
}