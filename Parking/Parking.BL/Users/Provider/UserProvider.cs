using AutoMapper;
using Parking.BL.Users.Entities;
using Parking.BL.Users.Entities.ActionModels;
using Parking.DataAccess;
using Parking.DataAccess.Entities;

namespace Parking.BL.Users.Provider;

public class UserProvider(IRepository<User> userRepository, IMapper mapper) : IUserProvider
{
    public IEnumerable<UserModel> GetUsers(ReadUserModel? filter = null)
    {
        var login = filter?.Login;
        var firstName = filter?.FirstName;
        var lastName = filter?.LastName;
        var birthday = filter?.Birthday;
        var patronymic = filter?.Patronymic;
        var userRole = filter?.UserRole;

        var users = userRepository.GetAll(x =>
            (login == null || x.Login == login) &&
            (firstName == null || x.FirstName.Contains(firstName)) &&
            (lastName == null || x.LastName.Contains(lastName)) &&
            (birthday == null || x.Birthday == birthday) &&
            (patronymic == null || x.Patronymic.Contains(patronymic)) &&
            (userRole == null || x.UserRole.Name.Contains(userRole.Name))
        );
        
        return mapper.Map<IEnumerable<UserModel>>(users);
    }

    public UserModel GetUserInfo(int id)
    {
        var entity = userRepository.GetById(id);
        
        if (entity == null)
        {
            throw new KeyNotFoundException();
        }

        return mapper.Map<UserModel>(entity);
    }
}