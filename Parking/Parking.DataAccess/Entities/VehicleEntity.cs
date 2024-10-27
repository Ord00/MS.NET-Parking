using System.ComponentModel.DataAnnotations.Schema;

namespace Parking.DataAccess.Entities;

[Table("Vehicles")]
public class VehicleEntity : BaseEntity
{
    public string Model { get; set; }
    public string Brand { get; set; }
    public string Colour { get; set; }
    
    public int VehicleTypeId { get; set; }
    public VehicleTypeEntity VehicleType { get; set; }
    
    public RegistrationPlateEntity RegistrationPlate { get; set; }
    
    public virtual ICollection<SessionEntity> Sessions { get; set; }
}