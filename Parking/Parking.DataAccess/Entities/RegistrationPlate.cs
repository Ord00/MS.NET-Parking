using System.ComponentModel.DataAnnotations.Schema;

namespace Parking.DataAccess.Entities;

[Table("RegistrationPlates")]
public class RegistrationPlate : BaseEntity
{
    public int RegistrationNumber { get; set; }
    public string Letters { get; set; }
    public int RegionCode { get; set; }
    public string Country { get; set; }
    
    public VehicleEntity Vehicle{ get; set; }
}