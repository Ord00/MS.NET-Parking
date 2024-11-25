using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parking.BL.Users.Entities.ActionModels;
using Parking.BL.Users.Entities.Responses;
using Parking.BL.Users.Manager;
using Parking.BL.Users.Provider;
using Parking.Validator.UserValidator;

namespace Parking.Controllers.UserController;

[ApiController]
[Route("[controller]")]
public class UsersController(
    IUserManager userManager,
    IUserProvider userProvider,
    IMapper mapper,
    Serilog.ILogger logger)
    : ControllerBase
{
    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserRequest request)
    {
        var validationResult = new CreateUserRequestValidator().Validate(request);
        if (validationResult.IsValid)
        {
            var createUserModel = mapper.Map<RegisterUserModel>(request);
            var userModel = userManager.CreateUser(createUserModel);
            return Ok(new UserListResponse
            {
                Users = [userModel]
            });
        }

        logger.Error(validationResult.ToString());
        return BadRequest(validationResult.ToString());
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = userProvider.GetUsers();
        return Ok(new UserListResponse
        {
            Users = users.ToList()
        });
    }

    [HttpGet]
    [Route("read")]
    public IActionResult GetFilteredUsers([FromQuery] ReadUserRequest request)
    {
        var userFilterModel = mapper.Map<ReadUserModel>(request);
        var users = userProvider.GetUsers(userFilterModel);
        return Ok(new UserListResponse
        {
            Users = users.ToList()
        });
    }
}