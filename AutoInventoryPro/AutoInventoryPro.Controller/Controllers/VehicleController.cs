using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Views.Vehicle.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AutoInventoryPro.Controllers.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleController(IVehicleService vehicleService) : ControllerBase
{
    private readonly IVehicleService _vehicleService = vehicleService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var vehicles = await _vehicleService.GetAllAsync();
        return Ok(vehicles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var vehicle = await _vehicleService.GetByIdAsync(id);

        if (vehicle is null)
            return NotFound();
        
        return Ok(vehicle);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] VehicleCreateRequest vehicleRequest)
    {
        await _vehicleService.AddAsync(vehicleRequest);
        //return CreatedAtAction(nameof(GetById), new { id = vehicle.Id }, vehicle);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody]VehicleUpdateRequest vehicleRequest)
    {
        var response = await _vehicleService.UpdateAsync(id, vehicleRequest);

        if (response is false)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _vehicleService.DeleteAsync(id);
        return NoContent();
    }
}
