using Parking.BL.Users.Entities;
using Parking.BL.Users.Entities.ActionModels;

namespace Parking.BL.Users.Provider;

public interface IUserProvider
{
    IEnumerable<UserModel> GetUsers(ReadUserModel? filter = null);
    
    UserModel GetUserInfo(int id);
}