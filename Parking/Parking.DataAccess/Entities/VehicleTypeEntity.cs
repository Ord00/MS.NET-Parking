using System.ComponentModel.DataAnnotations.Schema;

namespace Parking.DataAccess.Entities;

[Table("VehicleTypes")]
public class VehicleTypeEntity : BaseEntity
{
    public string VehicleTypeName { get; set; }
    
    public virtual ICollection<ZoneTariffEntity> ZoneTariffs { get; set; }
    public virtual ICollection<VehicleEntity> Vehicles { get; set; }
}