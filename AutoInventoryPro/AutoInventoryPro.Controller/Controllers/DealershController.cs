using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Models.Interfaces.Services;
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
    public async Task<IActionResult> Create([FromBody] Dealersh dealersh)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _dealershService.AddAsync(dealersh);
        return CreatedAtAction(nameof(GetById), new { id = dealersh.Id }, dealersh);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Dealersh dealersh)
    {
        if (id != dealersh.Id)
        {
            return BadRequest();
        }

        await _dealershService.UpdateAsync(dealersh);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _dealershService.DeleteAsync(id);
        return NoContent();
    }



}
