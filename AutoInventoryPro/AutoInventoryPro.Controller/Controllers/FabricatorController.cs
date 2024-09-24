using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Views.Fabricator.Requests;
using AutoInventoryPro.Views.Fabricator.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AutoInventoryPro.Controllers.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FabricatorController(IFabricatorService fabricatorService) : ControllerBase
{
    private readonly IFabricatorService _fabricatorService = fabricatorService;

    /// <summary>
    /// Retorna uma lista de todos os fabricantes.
    /// </summary>
    /// <returns>Uma lista de fabricantes.</returns>
    /// <response code="200">Retorna a lista de fabricantes.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<FabricatorResponse>), 200)]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<FabricatorResponse> fabricators = await _fabricatorService.GetAllAsync();
        return Ok(fabricators);
    }

    /// <summary>
    /// Retorna um fabricante específico pelo ID.
    /// </summary>
    /// <param name="id">ID do fabricante.</param>
    /// <returns>Detalhes do fabricante solicitado.</returns>
    /// <response code="200">Retorna o fabricante com o ID fornecido.</response>
    /// <response code="404">Se o fabricante não for encontrado.</response
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(FabricatorResponse), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        FabricatorResponse fabricator = await _fabricatorService.GetByIdAsync(id);
        if (fabricator == null)
        {
            return NotFound();
        }
        return Ok(fabricator);
    }

    /// <summary>
    /// Cria um novo fabricante.
    /// </summary>
    /// <param name="fabricatorRequest">Dados da fabricante a ser criado.</param>
    /// <returns>Confirmação da criação da fabricante.</returns>
    /// <response code="200">fabricante criado com sucesso.</response>
    /// <response code="400">Se a requisição estiver inválida.</response>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] FabricatorCreateRequest fabricatorRequest)
    {
        await _fabricatorService.AddAsync(fabricatorRequest);
        return Ok();
    }

    /// <summary>
    /// Atualiza os dados de uma fabricante específico.
    /// </summary>
    /// <param name="id">ID do fabricante a ser atualizado.</param>
    /// <param name="fabricatorRequest">Novos dados da fabricante.</param>
    /// <returns>Confirmação da atualização.</returns>
    /// <response code="204">fabricante atualizado com sucesso.</response>
    /// <response code="404">Se o fabricante não for encontrado.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(int id, [FromBody] FabricatorUpdateRequest fabricatorRequest)
    {
        var response = await _fabricatorService.UpdateAsync(id, fabricatorRequest);

        if (response is false)
            return NotFound();

        return NoContent();
    }

    /// <summary>
    /// Exclui uma fabricante específico.
    /// </summary>
    /// <param name="id">ID da fabricante a ser excluído.</param>
    /// <returns>Confirmação da exclusão.</returns>
    /// <response code="204">fabricante excluído com sucesso.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        await _fabricatorService.DeleteAsync(id);
        return NoContent();
    }

}

