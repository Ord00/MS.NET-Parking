using AutoMapper;
using Parking.BL.Sessions.Entities;
using Parking.BL.Sessions.Entities.ActionModels;
using Parking.DataAccess;
using Parking.DataAccess.Entities;

namespace Parking.BL.Sessions.Manager;

public class SessionManager(IRepository<SessionEntity> sessionsRepository, IMapper mapper) : ISessionManager
{
    public SessionModel CreateSession(CreateSessionModel model)
    {
        var entity = mapper.Map<SessionEntity>(model);
        entity = sessionsRepository.Save(entity);
        return mapper.Map<SessionModel>(entity);
    }

    public void DeleteSession(int id)
    {
        var entity = sessionsRepository.GetById(id);

        if (entity == null)
        {
            throw new KeyNotFoundException();
        }

        sessionsRepository.Delete(entity);

    }

    public SessionModel UpdateSession(int id, UpdateSessionModel model)
    {
        var entity = sessionsRepository.GetById(id);
            
        if (entity == null)
        {
            throw new KeyNotFoundException();
        }
            
        entity = sessionsRepository.Save(entity);
        return mapper.Map<SessionModel>(entity);
    }
}