using Parking.Settings;
using Microsoft.EntityFrameworkCore;
using Parking.DataAccess;

namespace Parking.IoC;

public static class DbContextConfigurator
{
    public static void ConfigureService(IServiceCollection services, ParkingSettings settings)
    {
        services.AddDbContextFactory<ParkingDbContext>(
            options => { options.UseNpgsql(settings.ParkingDbContextConnectionString); },
            ServiceLifetime.Scoped);
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ParkingDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate(); // makes last migrations to db and creates database if it doesn't exist
    }
}