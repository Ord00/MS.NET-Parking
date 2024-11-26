using Parking.DataAccess.Entities;

namespace Parking.BL.Users.Entities.ActionModels;

public class RegisterUserModel
{
    public String Email { get; set; }
    public String Password { get; set; }
    
    public UserRole Role { get; set; }
}