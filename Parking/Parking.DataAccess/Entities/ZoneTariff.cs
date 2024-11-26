using System.ComponentModel.DataAnnotations.Schema;

namespace Parking.DataAccess.Entities;

[Table("ZoneTariffs")]
public class ZoneTariff : BaseEntity
{
    public string ZoneName { get; set; }
    public decimal? ParkingPrice { get; set; }
    
    public int VehicleTypeId { get; set; }
    public VehicleType VehicleType { get; set; }
    
    public virtual ICollection<ZoneMove> ZoneMoves { get; set; }
}