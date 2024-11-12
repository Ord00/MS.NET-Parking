namespace Parking.BL.Users.Entities.ActionModels;

public class CreateUserModel
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime Birthday { get; set; }
    public string? Patronymic { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string UserRole { get; set; }
}