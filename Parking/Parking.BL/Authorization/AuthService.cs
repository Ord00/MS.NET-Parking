using AutoMapper;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Parking.BL.Users.Entities;
using Parking.BL.Users.Entities.ActionModels;
using Parking.DataAccess;
using Parking.DataAccess.Entities;
namespace Parking.BL.Authorization;

public class AuthService : IAuthService
{
    private UserManager<User> _userManager;
    private SignInManager<User> _signInManager;
    private IMapper _mapper;
    private string? _identityUri;
    
    public AuthService(
        UserManager<User> userManager, SignInManager<User> signInManager,
        IMapper mapper, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _identityUri = configuration.GetValue<string>("IdentityServer:Uri");
    }

    public async Task<UserModel> RegisterUser(RegisterUserModel model)
    {
        var existingUser = await _userManager.FindByEmailAsync(model.Email);
        if (existingUser != null)
        {
            throw new Exception("User already exists");
        }

        var user = new User
        {
            Email = model.Email,
            UserName = model.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            throw new Exception("Impossible to create user profile");
        }

        var createdUser = await _userManager.FindByEmailAsync(model.Email);
        return _mapper.Map<UserModel>(createdUser);
    }
    
    public async Task<TokenResponse> LoginUser(LoginUserModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user is null)
        {
            throw new Exception("User not found");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
        if (!result.Succeeded)
        {
            throw new Exception("Email or password is incorrect");
        }

        var client = new HttpClient();
        var disco = await client.GetDiscoveryDocumentAsync(_identityUri);
        if (disco.IsError)
        {
            throw new Exception(disco.Error);
        }

        var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
        {
            Address = disco.TokenEndpoint,
            ClientId = model.ClientId,
            ClientSecret = model.ClientSecret,
            UserName = model.Email,
            Password = model.Password,
            Scope = "api offline_access"
        });

        if (tokenResponse.IsError)
        {
            throw new Exception("Can't login user");
        }

        return tokenResponse;
    }
}