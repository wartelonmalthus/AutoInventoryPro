using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Views.Client.Requests;
using AutoInventoryPro.Views.Client.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AutoInventoryPro.Controllers.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController(IClientService clientService) : ControllerBase
{
    private readonly IClientService _clientService = clientService;


    /// <summary>
    /// Retorna uma lista de todos os clientes.
    /// </summary>
    /// <returns>Uma lista de clientes.</returns>
    /// <response code="200">Retorna a lista de clientes.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ClientResponse>), 200)]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<ClientResponse> clients = await _clientService.GetAllAsync();
        return Ok(clients);
    }

    /// <summary>
    /// Retorna um cliente específico pelo ID.
    /// </summary>
    /// <param name="id">ID do cliente.</param>
    /// <returns>Detalhes do cliente solicitado.</returns>
    /// <response code="200">Retorna o cliente com o ID fornecido.</response>
    /// <response code="404">Se o cliente não for encontrado.</response
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ClientResponse), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        ClientResponse client = await _clientService.GetByIdAsync(id);

        if (client == null)
            return NotFound();
        
        return Ok(client);
    }

    /// <summary>
    /// Cria um novo cliente.
    /// </summary>
    /// <param name="clientRequest">Dados do cliente a ser criado.</param>
    /// <returns>Confirmação da criação do cliente.</returns>
    /// <response code="200">Cliente criado com sucesso.</response>
    /// <response code="400">Se a requisição estiver inválida.</response>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] ClientCreateRequest clientRequest)
    {
        await _clientService.AddAsync(clientRequest);
        return Ok();
    }

    /// <summary>
    /// Atualiza os dados de um cliente específico.
    /// </summary>
    /// <param name="id">ID do cliente a ser atualizado.</param>
    /// <param name="clientRequest">Novos dados do cliente.</param>
    /// <returns>Confirmação da atualização.</returns>
    /// <response code="204">Cliente atualizado com sucesso.</response>
    /// <response code="404">Se o cliente não for encontrado.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(int id, [FromBody] ClientUpdateRequest clientRequest)
    {
        bool response = await _clientService.UpdateAsync(id, clientRequest);

        if (response is false)
            return NotFound();

        return NoContent();
    }
    /// <summary>
    /// Exclui um cliente específico.
    /// </summary>
    /// <param name="id">ID do cliente a ser excluído.</param>
    /// <returns>Confirmação da exclusão.</returns>
    /// <response code="204">Cliente excluído com sucesso.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        await _clientService.DeleteAsync(id);
        return NoContent();
    }


}
