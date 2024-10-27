using System.ComponentModel.DataAnnotations.Schema;

namespace Parking.DataAccess.Entities;

[Table("CreditCards")]
public class CreditCardEntity : BaseEntity
{
    public string CardNumber { get; set; }
    public string Bank { get; set; }
    
    public virtual ICollection<UserEntity> Users { get; set; }
}