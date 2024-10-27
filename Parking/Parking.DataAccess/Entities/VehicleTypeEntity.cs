using System.ComponentModel.DataAnnotations.Schema;

namespace Parking.DataAccess.Entities;

[Table("VehicleType")]
public class VehicleTypeEntity
{
    public string VehicleTypeName { get; set; }
    
    public virtual ICollection<ZoneTariffEntity> ZoneTariffs { get; set; }
    public virtual ICollection<VehicleEntity> Vehicles { get; set; }
}