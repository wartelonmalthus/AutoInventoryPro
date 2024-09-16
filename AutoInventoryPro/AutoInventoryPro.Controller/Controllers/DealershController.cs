using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Services.Services;
using AutoInventoryPro.Views.Dealersh.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AutoInventoryPro.Controllers.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DealershController(IDealershService dealershService) : ControllerBase
{
    private readonly IDealershService _dealershService = dealershService;


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var dealershes = await _dealershService.GetAllAsync();
        return Ok(dealershes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var dealersh = await _dealershService.GetByIdAsync(id);
        if (dealersh == null)
        {
            return NotFound();
        }
        return Ok(dealersh);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DealershCreateRequest dealersh)
    {
        await _dealershService.AddAsync(dealersh);
        //return CreatedAtAction(nameof(GetById), new { id = dealersh.Id }, dealersh);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] DealershUpdateRequest dealershRequest)
    {
        var response = await _dealershService.UpdateAsync(id, dealershRequest);

        if (response is false)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _dealershService.DeleteAsync(id);
        return NoContent();
    }
}
