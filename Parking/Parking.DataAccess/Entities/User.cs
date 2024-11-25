using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Parking.DataAccess.Entities;

[Table("Users")]
public class User : IdentityUser<Guid>, IBaseEntity
{
    public int Id { get; set; }
    public Guid ExternalId { get; set; }
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime Birthday { get; set; }
    public string? Patronymic { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string UserRole { get; set; }
    
    public virtual ICollection<CreditCard> CreditCards { get; set; }
    public virtual ICollection<Session> Sessions { get; set; }
}

public class UserRole : IdentityRole<Guid>
{
}