namespace Parking.BL.Users.Entities.ActionModels;

public class RegisterUserModel
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime Birthday { get; set; }
    public string? Patronymic { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserRole { get; set; }
}