using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Models.Interfaces.Services;
using AutoInventoryPro.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoInventoryPro.Controllers.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SaleController(ISaleService saleService) : ControllerBase
{
    private readonly ISaleService _saleService = saleService;


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var sales = await _saleService.GetAllAsync();
        return Ok(sales);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var sale = await _saleService.GetByIdAsync(id);
        if (sale == null)
        {
            return NotFound();
        }
        return Ok(sale);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Sale sale)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _saleService.AddAsync(sale);
        return CreatedAtAction(nameof(GetById), new { id = sale.Id }, sale);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Sale sale)
    {
        if (id != sale.Id)
        {
            return BadRequest();
        }

        await _saleService.UpdateAsync(sale);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _saleService.DeleteAsync(id);
        return NoContent();
    }



}
