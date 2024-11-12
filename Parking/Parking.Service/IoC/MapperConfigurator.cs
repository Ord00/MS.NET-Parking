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
        });
    }
}