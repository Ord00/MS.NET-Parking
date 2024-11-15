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
        
        services.AddScoped<IRepository<UserEntity>>(x => 
            new Repository<UserEntity>(x.GetRequiredService<IDbContextFactory<ParkingDbContext>>()));
        services.AddScoped<IUserProvider>(x => 
            new UserProvider(x.GetRequiredService<IRepository<UserEntity>>(), 
                x.GetRequiredService<IMapper>()));
        services.AddScoped<IUserManager>(x =>
            new UserManager(x.GetRequiredService<IRepository<UserEntity>>(),
                x.GetRequiredService<IMapper>()));
        
        services.AddScoped<IRepository<VehicleEntity>>(x => 
            new Repository<VehicleEntity>(x.GetRequiredService<IDbContextFactory<ParkingDbContext>>()));
        services.AddScoped<IVehicleProvider>(x => 
            new VehicleProvider(x.GetRequiredService<IRepository<VehicleEntity>>(), 
                x.GetRequiredService<IMapper>()));
        services.AddScoped<IVehicleManager>(x =>
            new VehicleManager(x.GetRequiredService<IRepository<VehicleEntity>>(),
                x.GetRequiredService<IMapper>()));
        
        services.AddScoped<IRepository<SessionEntity>>(x => 
            new Repository<SessionEntity>(x.GetRequiredService<IDbContextFactory<ParkingDbContext>>()));
        services.AddScoped<ISessionProvider>(x => 
            new SessionProvider(x.GetRequiredService<IRepository<SessionEntity>>(), 
                x.GetRequiredService<IMapper>()));
        services.AddScoped<ISessionManager>(x =>
            new SessionManager(x.GetRequiredService<IRepository<SessionEntity>>(),
                x.GetRequiredService<IMapper>()));
    }
}