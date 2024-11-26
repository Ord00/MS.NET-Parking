using System.ComponentModel.DataAnnotations.Schema;

namespace Parking.DataAccess.Entities;

[Table("Vehicles")]
public class VehicleEntity : BaseEntity
{
    public string Model { get; set; }
    public string Brand { get; set; }
    public string Colour { get; set; }
    
    public int VehicleTypeId { get; set; }
    public VehicleType VehicleType { get; set; }
    
    public int RegistrationPlateId { get; set; }
    public RegistrationPlate RegistrationPlate { get; set; }
    
    public virtual ICollection<Session> Sessions { get; set; }
}