using Duende.IdentityServer.Models;
using Microsoft.IdentityModel.Tokens;
using Parking.DataAccess;
using Parking.DataAccess.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.IoC;

public class AuthorisationConfigurator
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        var identityUri = configuration.GetValue<string>("IdentityServer:Uri");
        
        services.AddIdentity<User, UserRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvwxyzABCDEFGHIKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 1;
            })
            .AddEntityFrameworkStores<ParkingDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        services.AddIdentityServer()
            .AddInMemoryApiScopes([new ApiScope("api", "Access to WebAPI")])
            .AddInMemoryClients([
                new Client
                {
                    ClientId = "desktop",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    [
                        new Secret("secret".Sha256())
                    ],
                    AllowedScopes = ["api"]
                },
                new Client
                {
                    ClientId = "swagger",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    [
                        new Secret("swagger".Sha256())
                    ],
                    AllowedScopes = ["api"]
                },
            ])
            .AddAspNetIdentity<User>();

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        {
            options.RequireHttpsMetadata = false;
            options.Authority = identityUri;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = false,
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireSignedTokens = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            options.Audience = "api";
        });

        services.AddAuthorization();
    }
    
    public static void ConfigureApplication(IApplicationBuilder app)
    {
        app.UseIdentityServer();
        app.UseAuthentication();
        app.UseAuthorization();
    }
}