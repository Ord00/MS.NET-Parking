using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parking.BL.Sessions.Entities.ActionModels;
using Parking.BL.Sessions.Entities.Responses;
using Parking.BL.Sessions.Manager;
using Parking.BL.Sessions.Provider;
using Parking.Validator.SessionValidator;

namespace Parking.Controllers.SessionController;

[ApiController]
[Route("[controller]")]
public class SessionsController(
    ISessionManager sessionManager,
    ISessionProvider sessionProvider,
    IMapper mapper,
    Serilog.ILogger logger)
    : ControllerBase
{
    [HttpPost]
    public IActionResult CreateSession([FromBody] CreateSessionRequest request)
    {
        var validationResult = new CreateSessionRequestValidator().Validate(request);
        if (validationResult.IsValid)
        {
            var createSessionModel = mapper.Map<CreateSessionModel>(request);
            var sessionModel = sessionManager.CreateSession(createSessionModel);
            return Ok(new SessionListResponse
            {
                Sessions = [sessionModel]
            });
        }

        logger.Error(validationResult.ToString());
        return BadRequest(validationResult.ToString());
    }

    [HttpGet]
    public IActionResult GetAllSessions()
    {
        var sessions = sessionProvider.GetSessions();
        return Ok(new SessionListResponse
        {
            Sessions = sessions.ToList()
        });
    }

    [HttpGet]
    [Route("read")]
    public IActionResult GetFilteredSessions([FromQuery] ReadSessionRequest request)
    {
        var sessionFilterModel = mapper.Map<ReadSessionModel>(request);
        var sessions = sessionProvider.GetSessions(sessionFilterModel);
        return Ok(new SessionListResponse
        {
            Sessions = sessions.ToList()
        });
    }
}