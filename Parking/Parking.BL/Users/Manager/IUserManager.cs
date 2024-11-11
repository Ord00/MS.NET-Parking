using Parking.BL.Users.Entities;
using Parking.BL.Users.Entities.Responses;

namespace Parking.BL.Users.Manager;

public interface IUserManager
{
    UserModel CreateUser(CreateUserModel model);
    
    UserModel UpdateUser(int id, UpdateUserModel model);
    
    void DeleteUser(int id);
}