using Parking.BL.Mapper;
using Parking.Mapper;

namespace Parking.IoC;

public static class MapperConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<UserModelsProfile>();
            config.AddProfile<UserServicesProfile>();
            
            config.AddProfile<VehicleModelsProfile>();
            config.AddProfile<VehicleServicesProfile>();
            
            config.AddProfile<SessionModelsProfile>();
            config.AddProfile<SessionServicesProfile>();
        });
    }
}