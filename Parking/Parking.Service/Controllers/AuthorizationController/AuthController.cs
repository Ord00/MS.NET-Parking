using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parking.BL.Authorization;
using Parking.BL.Users.Entities.ActionModels;
using Parking.BL.Users.Entities.Responses;
using Parking.Controllers.UserController.Requests;

namespace Parking.Controllers.AuthorizationController;

public class AuthController(IAuthService authService,
    IMapper mapper,
    Serilog.ILogger logger) : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
    {
        try
        {
            var registerUserModel = mapper.Map<RegisterUserModel>(request);
            var userModel = await authService.RegisterUser(registerUserModel);
            return Ok(new UserListResponse
            {
                Users = [userModel]
            });
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet]
    [Route("login")]
    public async Task<IActionResult> LoginUser([FromQuery] LoginUserRequest request)
    {
        try
        {
            var loginUserModel = mapper.Map<LoginUserModel>(request);
            var tokenResponse = await authService.LoginUser(loginUserModel);
            return Ok(tokenResponse);
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
            return BadRequest(ex.Message);
        }
    }
}