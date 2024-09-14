using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Models.Interfaces.Services;
using AutoInventoryPro.Services.Services;
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
        if (vehicle == null)
        {
            return NotFound();
        }
        return Ok(vehicle);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Vehicle vehicle)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _vehicleService.AddAsync(vehicle);
        return CreatedAtAction(nameof(GetById), new { id = vehicle.Id }, vehicle);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Vehicle vehicle)
    {
        if (id != vehicle.Id)
        {
            return BadRequest();
        }

        await _vehicleService.UpdateAsync(vehicle);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _vehicleService.DeleteAsync(id);
        return NoContent();
    }
}
