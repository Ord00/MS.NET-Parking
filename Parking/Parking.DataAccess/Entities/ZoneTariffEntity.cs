using System.ComponentModel.DataAnnotations.Schema;

namespace Parking.DataAccess.Entities;

[Table("ZoneTariff")]
public class ZoneTariffEntity : BaseEntity
{
    public string ZoneName { get; set; }
    public decimal? ParkingPrice { get; set; }
    
    public int VehicleTypeId { get; set; }
    public VehicleTypeEntity VehicleType { get; set; }
    
    public virtual ICollection<ZoneMoveEntity> ZoneMoves { get; set; }
}