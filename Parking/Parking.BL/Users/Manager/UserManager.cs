using AutoMapper;
using Parking.BL.Users.Entities;
using Parking.BL.Users.Entities.ActionModels;
using Parking.DataAccess;
using Parking.DataAccess.Entities;

namespace Parking.BL.Users.Manager;

public class UserManager(IRepository<User> usersRepository, IMapper mapper) : IUserManager
{
    public UserModel CreateUser(CreateUserModel model)
        {
            var entity = mapper.Map<User>(model);
            entity = usersRepository.Save(entity);
            return mapper.Map<UserModel>(entity);
        }

        public void DeleteUser(int id)
        {
            var entity = usersRepository.GetById(id);

            if (entity == null)
            {
                throw new KeyNotFoundException();
            }

            usersRepository.Delete(entity);

        }

        public UserModel UpdateUser(int id, UpdateUserModel model)
        {
            var entity = usersRepository.GetById(id);
            
            if (entity == null)
            {
                throw new KeyNotFoundException();
            }
            
            entity = usersRepository.Save(entity);
            return mapper.Map<UserModel>(entity);
        }
}