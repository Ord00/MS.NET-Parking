using System.ComponentModel.DataAnnotations.Schema;

namespace Parking.DataAccess.Entities;

[Table("ZoneMove")]
public class ZoneMoveEntity : BaseEntity
{
    public DateTime EntryDate { get; set; }
    public DateTime? ExitDate { get; set; }
    
    public int SessionId { get; set; }
    public SessionEntity Session { get; set; }
    
    public int ZoneTariffId { get; set; }
    public ZoneTariffEntity ZoneTariff { get; set; }
}