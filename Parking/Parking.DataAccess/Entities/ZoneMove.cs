using System.ComponentModel.DataAnnotations.Schema;

namespace Parking.DataAccess.Entities;

[Table("ZoneMoves")]
public class ZoneMove : BaseEntity
{
    public DateTime EntryDate { get; set; }
    public DateTime? ExitDate { get; set; }
    
    public int SessionId { get; set; }
    public Session Session { get; set; }
    
    public int ZoneTariffId { get; set; }
    public ZoneTariff ZoneTariff { get; set; }
}