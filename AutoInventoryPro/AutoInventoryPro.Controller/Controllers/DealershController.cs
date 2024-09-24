using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Views.Dealersh.Requests;
using AutoInventoryPro.Views.Dealersh.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AutoInventoryPro.Controllers.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DealershController(IDealershService dealershService) : ControllerBase
{
    private readonly IDealershService _dealershService = dealershService;


    /// <summary>
    /// Retorna uma lista de todas as concessionárias.
    /// </summary>
    /// <returns>Uma lista de concessionárias.</returns>
    /// <response code="200">Retorna a lista de concessionárias.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<DealershResponse>), 200)]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<DealershResponse> dealershes = await _dealershService.GetAllAsync();
        return Ok(dealershes);
    }
    /// <summary>
    /// Retorna um concessionária específico pelo ID.
    /// </summary>
    /// <param name="id">ID do concessionária.</param>
    /// <returns>Detalhes do concessionária solicitado.</returns>
    /// <response code="200">Retorna o concessionária com o ID fornecido.</response>
    /// <response code="404">Se o concessionária não for encontrado.</response
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(DealershResponse), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        DealershResponse dealersh = await _dealershService.GetByIdAsync(id);
        if (dealersh == null)
        {
            return NotFound();
        }
        return Ok(dealersh);
    }

    /// <summary>
    /// Cria um novo concessionária.
    /// </summary>
    /// <param name="dealersh">Dados da concessionária a ser criado.</param>
    /// <returns>Confirmação da criação da concessionária.</returns>
    /// <response code="200">concessionária criado com sucesso.</response>
    /// <response code="400">Se a requisição estiver inválida.</response>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] DealershCreateRequest dealersh)
    {
        await _dealershService.AddAsync(dealersh);
        return Ok();
    }
    /// <summary>
    /// Atualiza os dados de uma concessionária específico.
    /// </summary>
    /// <param name="id">ID do concessionária a ser atualizado.</param>
    /// <param name="dealershRequest">Novos dados da concessionária.</param>
    /// <returns>Confirmação da atualização.</returns>
    /// <response code="204">concessionária atualizado com sucesso.</response>
    /// <response code="404">Se o concessionária não for encontrado.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(int id, [FromBody] DealershUpdateRequest dealershRequest)
    {
        var response = await _dealershService.UpdateAsync(id, dealershRequest);

        if (response is false)
            return NotFound();

        return NoContent();
    }
    /// <summary>
    /// Exclui uma concessionária específico.
    /// </summary>
    /// <param name="id">ID da concessionária a ser excluído.</param>
    /// <returns>Confirmação da exclusão.</returns>
    /// <response code="204">concessionária excluído com sucesso.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        await _dealershService.DeleteAsync(id);
        return NoContent();
    }
}
