using System.ComponentModel.DataAnnotations.Schema;

namespace Parking.DataAccess.Entities;

[Table("VehicleTypes")]
public class VehicleType : BaseEntity
{
    public string VehicleTypeName { get; set; }
    
    public virtual ICollection<ZoneTariff> ZoneTariffs { get; set; }
    public virtual ICollection<VehicleEntity> Vehicles { get; set; }
}