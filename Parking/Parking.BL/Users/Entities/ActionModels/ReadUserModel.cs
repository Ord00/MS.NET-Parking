using Parking.DataAccess.Entities;

namespace Parking.BL.Users.Entities.ActionModels;

public class ReadUserModel
{
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public DateTime? Birthday { get; set; }
    public string? Patronymic { get; set; }
    public string? Login { get; set; }
    public UserRole? UserRole { get; set; }
}