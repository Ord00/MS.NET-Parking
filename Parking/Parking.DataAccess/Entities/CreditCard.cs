using System.ComponentModel.DataAnnotations.Schema;

namespace Parking.DataAccess.Entities;

[Table("CreditCards")]
public class CreditCard : BaseEntity
{
    public string CardNumber { get; set; }
    public string Bank { get; set; }
    
    public virtual ICollection<User> Users { get; set; }
}