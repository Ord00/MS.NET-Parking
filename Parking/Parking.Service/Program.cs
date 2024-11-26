using Parking.DI;
using Parking.IoC;
using Parking.Settings;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var settings = ParkingSettingsReader.Read(configuration);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

ApplicationConfigurator.ConfigureServices(builder, settings);

var app = builder.Build();

ApplicationConfigurator.ConfigureApplication(app);

app.UseHttpsRedirection();
AuthorizationConfigurator.ConfigureApplication(app);
app.MapControllers();

app.Run();