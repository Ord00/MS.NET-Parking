using Parking.DI;
using Parking.IoC;
using Parking.Settings;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var settings = ParkingSettingsReader.Read(configuration);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

DbContextConfigurator.ConfigureService(builder.Services, settings);
SerilogConfigurator.ConfigureService(builder);
SwaggerConfigurator.ConfigureServices(builder.Services);
ApplicationConfigurator.ConfigureServices(builder, settings);
AuthorizationConfigurator.ConfigureServices(builder.Services, configuration);

var app = builder.Build();

SerilogConfigurator.ConfigureApplication(app);
SwaggerConfigurator.ConfigureApplication(app);
DbContextConfigurator.ConfigureApplication(app);
ApplicationConfigurator.ConfigureApplication(app);

app.UseHttpsRedirection();
AuthorizationConfigurator.ConfigureApplication(app);
app.MapControllers();

app.Run();