using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Parking.BL.Sessions.Manager;
using Parking.BL.Sessions.Provider;
using Parking.BL.Users.Manager;
using Parking.BL.Users.Provider;
using Parking.BL.Vehicles.Manager;
using Parking.BL.Vehicles.Provider;
using Parking.DataAccess;
using Parking.DataAccess.Entities;
using Parking.Settings;

namespace Parking.IoC;

public class ServicesConfigurator
{
    public static void ConfigureServices(IServiceCollection services, ParkingSettings settings)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
        services.AddScoped<IRepository<User>>(x => 
            new Repository<User>(x.GetRequiredService<IDbContextFactory<ParkingDbContext>>()));
        services.AddScoped<IUserProvider>(x => 
            new UserProvider(x.GetRequiredService<IRepository<User>>(), 
                x.GetRequiredService<IMapper>()));
        services.AddScoped<IUserManager>(x =>
            new UserManager(x.GetRequiredService<IRepository<User>>(),
                x.GetRequiredService<IMapper>()));
        
        services.AddScoped<IRepository<VehicleEntity>>(x => 
            new Repository<VehicleEntity>(x.GetRequiredService<IDbContextFactory<ParkingDbContext>>()));
        services.AddScoped<IVehicleProvider>(x => 
            new VehicleProvider(x.GetRequiredService<IRepository<VehicleEntity>>(), 
                x.GetRequiredService<IMapper>()));
        services.AddScoped<IVehicleManager>(x =>
            new VehicleManager(x.GetRequiredService<IRepository<VehicleEntity>>(),
                x.GetRequiredService<IMapper>()));
        
        services.AddScoped<IRepository<Session>>(x => 
            new Repository<Session>(x.GetRequiredService<IDbContextFactory<ParkingDbContext>>()));
        services.AddScoped<ISessionProvider>(x => 
            new SessionProvider(x.GetRequiredService<IRepository<Session>>(), 
                x.GetRequiredService<IMapper>()));
        services.AddScoped<ISessionManager>(x =>
            new SessionManager(x.GetRequiredService<IRepository<Session>>(),
                x.GetRequiredService<IMapper>()));
    }
}