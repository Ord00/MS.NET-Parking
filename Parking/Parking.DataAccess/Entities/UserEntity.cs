using System.ComponentModel.DataAnnotations.Schema;

namespace Parking.DataAccess.Entities;

[Table("Users")]
public class UserEntity : BaseEntity
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime Birthday { get; set; }
    public string? Patronymic { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string UserRole { get; set; }
    
    public virtual ICollection<CreditCardEntity> CreditCards { get; set; }
    public virtual ICollection<SessionEntity> Sessions { get; set; }
}