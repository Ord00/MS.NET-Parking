namespace Parking.BL.Users.Entities.Responses;

public class ReadUserModel
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime Birthday { get; set; }
    public string? Patronymic { get; set; }
    public string Login { get; set; }
    public string UserRole { get; set; }
}