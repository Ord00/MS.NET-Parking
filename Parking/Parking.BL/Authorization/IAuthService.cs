using IdentityModel.Client;
using Parking.BL.Users.Entities;
using Parking.BL.Users.Entities.ActionModels;

namespace Parking.BL.Authorization;

public interface IAuthService
{
    Task<UserModel> RegisterUser(RegisterUserModel model);
    Task<TokenResponse> LoginUser(LoginUserModel model);
}