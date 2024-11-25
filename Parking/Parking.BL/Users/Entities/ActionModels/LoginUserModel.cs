namespace Parking.BL.Users.Entities.ActionModels;

public class LoginUserModel
{
    public string ClientId{ get; set; }
    public string? ClientSecret { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}