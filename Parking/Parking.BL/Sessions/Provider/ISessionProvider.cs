using Parking.BL.Sessions.Entities;
using Parking.BL.Sessions.Entities.ActionModels;

namespace Parking.BL.Sessions.Provider;

public interface ISessionProvider
{
    IEnumerable<SessionModel> GetSessions(ReadSessionModel? filter = null);
    
    SessionModel GetSessionInfo(int id);
}