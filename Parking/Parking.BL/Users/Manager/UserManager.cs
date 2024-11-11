using AutoMapper;
using Parking.BL.Users.Entities;
using Parking.BL.Users.Entities.Responses;
using Parking.DataAccess;
using Parking.DataAccess.Entities;

namespace Parking.BL.Users.Manager;

public class UserManager(IRepository<UserEntity> usersRepository, IMapper mapper) : IUserManager
{
    public UserModel CreateUser(CreateUserModel model)
        {
            var entity = mapper.Map<UserEntity>(model);
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