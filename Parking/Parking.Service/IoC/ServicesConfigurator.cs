using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Parking.BL.Users.Manager;
using Parking.BL.Users.Provider;
using Parking.DataAccess;
using Parking.DataAccess.Entities;
using Parking.Settings;

namespace Parking.IoC;

public class ServicesConfigurator
{
    public static void ConfigureServices(IServiceCollection services, ParkingSettings settings)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IRepository<UserEntity>>(x => 
            new Repository<UserEntity>(x.GetRequiredService<IDbContextFactory<ParkingDbContext>>()));
        services.AddScoped<IUserProvider>(x => 
            new UserProvider(x.GetRequiredService<IRepository<UserEntity>>(), 
                x.GetRequiredService<IMapper>()));
        services.AddScoped<IUserManager>(x =>
            new UserManager(x.GetRequiredService<IRepository<UserEntity>>(),
                x.GetRequiredService<IMapper>()));
    }
}