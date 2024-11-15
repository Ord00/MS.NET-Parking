using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parking.BL.Vehicles.Entities.ActionModels;
using Parking.BL.Vehicles.Entities.Responses;
using Parking.BL.Vehicles.Manager;
using Parking.BL.Vehicles.Provider;
using Parking.Validator.VehicleValidator;

namespace Parking.Controllers.VehicleController;

[ApiController]
[Route("[controller]")]
public class VehiclesController(
    IVehicleManager vehicleManager,
    IVehicleProvider vehicleProvider,
    IMapper mapper,
    Serilog.ILogger logger)
    : ControllerBase
{
    [HttpPost]
    public IActionResult CreateVehicle([FromBody] CreateVehicleRequest request)
    {
        var validationResult = new CreateVehicleRequestValidator().Validate(request);
        if (validationResult.IsValid)
        {
            var createVehicleModel = mapper.Map<CreateVehicleModel>(request);
            var vehicleModel = vehicleManager.CreateVehicle(createVehicleModel);
            return Ok(new VehicleListResponse
            {
                Vehicles = [vehicleModel]
            });
        }

        logger.Error(validationResult.ToString());
        return BadRequest(validationResult.ToString());
    }

    [HttpGet]
    public IActionResult GetAllVehicles()
    {
        var vehicles = vehicleProvider.GetVehicles();
        return Ok(new VehicleListResponse
        {
            Vehicles = vehicles.ToList()
        });
    }

    [HttpGet]
    [Route("read")]
    public IActionResult GetFilteredVehicles([FromQuery] ReadVehicleRequest request)
    {
        var vehicleFilterModel = mapper.Map<ReadVehicleModel>(request);
        var vehicles = vehicleProvider.GetVehicles(vehicleFilterModel);
        return Ok(new VehicleListResponse
        {
            Vehicles = vehicles.ToList()
        });
    }
}