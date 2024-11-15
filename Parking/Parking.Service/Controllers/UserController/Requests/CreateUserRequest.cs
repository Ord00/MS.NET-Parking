namespace Parking.Controllers.UserController;

public class CreateUserRequest
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime Birthday { get; set; }
    public string? Patronymic { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string UserRole { get; set; }
}