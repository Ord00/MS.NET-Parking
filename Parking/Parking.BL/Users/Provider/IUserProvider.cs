using Parking.BL.Users.Entities;
using Parking.BL.Users.Entities.Responses;
using Parking.Controllers;
using Parking.Controllers.UserController;

namespace Parking.BL.Users.Provider;

public interface IUserProvider
{
    IEnumerable<UserModel> GetUsers(ReadUserModel filter);
    
    UserModel GetUserInfo(int id);
}