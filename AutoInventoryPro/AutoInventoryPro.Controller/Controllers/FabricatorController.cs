using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Views.Fabricator.Requests;
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
    public async Task<IActionResult> Create([FromBody] FabricatorCreateRequest fabricatorRequest)
    {
        await _fabricatorService.AddAsync(fabricatorRequest);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] FabricatorUpdateRequest fabricatorRequest)
    {
        var response = await _fabricatorService.UpdateAsync(id, fabricatorRequest);

        if (response is false)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _fabricatorService.DeleteAsync(id);
        return NoContent();
    }

}

