using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Models.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoInventoryPro.Controllers.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FabricatorController(IFabricatorService fabricatorService) : ControllerBase
{
    private readonly IFabricatorService _fabricatorService = fabricatorService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var fabricators = await _fabricatorService.GetAllAsync();
        return Ok(fabricators);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var fabricator = await _fabricatorService.GetByIdAsync(id);
        if (fabricator == null)
        {
            return NotFound();
        }
        return Ok(fabricator);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Fabricator fabricator)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _fabricatorService.AddAsync(fabricator);
        return CreatedAtAction(nameof(GetById), new { id = fabricator.Id }, fabricator);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Fabricator fabricator)
    {
        if (id != fabricator.Id)
        {
            return BadRequest();
        }

        await _fabricatorService.UpdateAsync(fabricator);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _fabricatorService.DeleteAsync(id);
        return NoContent();
    }

}

