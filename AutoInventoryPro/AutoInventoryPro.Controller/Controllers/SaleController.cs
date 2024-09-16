using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Views.Sale.Requests;
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
    public async Task<IActionResult> Create([FromBody] SaleCreateRequest saleRequest)
    {
        await _saleService.AddAsync(saleRequest);
        //return CreatedAtAction(nameof(GetById), new { id = sale.Id }, sale);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] SaleUpdateRequest saleRequest)
    {
        await _saleService.UpdateAsync(saleRequest);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _saleService.DeleteAsync(id);
        return NoContent();
    }
}
