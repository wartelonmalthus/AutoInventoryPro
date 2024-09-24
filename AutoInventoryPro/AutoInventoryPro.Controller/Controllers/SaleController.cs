using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Views.Sale.Requests;
using AutoInventoryPro.Views.Sale.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AutoInventoryPro.Controllers.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SaleController(ISaleService saleService) : ControllerBase
{
    private readonly ISaleService _saleService = saleService;

    /// <summary>
    /// Retorna uma lista de todas as vendas.
    /// </summary>
    /// <returns>Uma lista de vendas.</returns>
    /// <response code="200">Retorna a lista de vendas.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<SaleResponse>), 200)]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<SaleResponse> sales = await _saleService.GetAllAsync();
        return Ok(sales);
    }

    /// <summary>
    /// Retorna um venda específico pelo ID.
    /// </summary>
    /// <param name="id">ID do venda.</param>
    /// <returns>Detalhes do venda solicitado.</returns>
    /// <response code="200">Retorna o venda com o ID fornecido.</response>
    /// <response code="404">Se o venda não for encontrado.</response
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(SaleResponse), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        SaleResponse sale = await _saleService.GetByIdAsync(id);
        if (sale == null)
        {
            return NotFound();
        }
        return Ok(sale);
    }
    /// <summary>
    /// Cria um novo venda.
    /// </summary>
    /// <param name="saleRequest">Dados da venda a ser criado.</param>
    /// <returns>Confirmação da criação da venda.</returns>
    /// <response code="200">venda criado com sucesso.</response>
    /// <response code="400">Se a requisição estiver inválida.</response>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] SaleCreateRequest saleRequest)
    {
        var response = await _saleService.AddAsync(saleRequest);

        if (response is false)
            return NotFound();

        return Ok();
    }

    /// <summary>
    /// Atualiza os dados de uma venda específico.
    /// </summary>
    /// <param name="id">ID do venda a ser atualizado.</param>
    /// <param name="saleRequest">Novos dados da venda.</param>
    /// <returns>Confirmação da atualização.</returns>
    /// <response code="204">venda atualizado com sucesso.</response>
    /// <response code="404">Se o venda não for encontrado.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(int id, [FromBody] SaleUpdateRequest saleRequest)
    {
        var response = await _saleService.UpdateAsync(id, saleRequest);

        if (response is false)
            return NotFound();

        return NoContent();
    }


    /// <summary>
    /// Exclui uma venda específico.
    /// </summary>
    /// <param name="id">ID da venda a ser excluído.</param>
    /// <returns>Confirmação da exclusão.</returns>
    /// <response code="204">venda excluído com sucesso.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        await _saleService.DeleteAsync(id);
        return NoContent();
    }
}
