using Parking.BL.Sessions.Entities;
using Parking.BL.Sessions.Entities.ActionModels;

namespace Parking.BL.Sessions.Manager;

public interface ISessionManager
{
    SessionModel CreateSession(CreateSessionModel model);
    
    SessionModel UpdateSession(int id, UpdateSessionModel model);
    
    void DeleteSession(int id);
}