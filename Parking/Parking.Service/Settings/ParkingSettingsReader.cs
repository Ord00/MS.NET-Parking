namespace Parking.Settings;

public class ParkingSettingsReader
{
    public static ParkingSettings Read(IConfiguration configuration)
    {
        return new ParkingSettings()
        {
            ParkingDbContextConnectionString = configuration.GetValue<string>("ParkingDbContext")
        };
    }
}