using AutoMapper;
using Parking.BL.Sessions.Entities;
using Parking.BL.Sessions.Entities.ActionModels;
using Parking.DataAccess;
using Parking.DataAccess.Entities;

namespace Parking.BL.Sessions.Provider;

public class SessionProvider(IRepository<Session> sessionsRepository, IMapper mapper) : ISessionProvider
{
    public IEnumerable<SessionModel> GetSessions(ReadSessionModel? filter = null)
    {
        var entryDate = filter?.EntryDate;
        var exitDate = filter?.ExitDate;
        var userId = filter?.UserId;
        var vehicleId = filter?.VehicleId;

        var users = sessionsRepository.GetAll(x =>
            (entryDate == null || x.EntryDate == entryDate) &&
            (exitDate == null || x.ExitDate == exitDate) &&
            (userId == null || x.UserId == userId) &&
            (vehicleId == null || x.VehicleId == vehicleId)
        );
        
        return mapper.Map<IEnumerable<SessionModel>>(users);
    }

    public SessionModel GetSessionInfo(int id)
    {
        var entity = sessionsRepository.GetById(id);
        
        if (entity == null)
        {
            throw new KeyNotFoundException();
        }

        return mapper.Map<SessionModel>(entity);
    }
}