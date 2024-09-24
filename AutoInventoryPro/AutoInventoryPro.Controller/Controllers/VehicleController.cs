using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Views.User.Responses;
using AutoInventoryPro.Views.Vehicle.Requests;
using AutoInventoryPro.Views.Vehicle.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AutoInventoryPro.Controllers.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleController(IVehicleService vehicleService) : ControllerBase
{
    private readonly IVehicleService _vehicleService = vehicleService;

    /// <summary>
    /// Retorna uma lista de todss os veículos.
    /// </summary>
    /// <returns>Uma lista de veículos.</returns>
    /// <response code="200">Retorna a lista de veículos.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<VehicleResponse>), 200)]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<VehicleResponse> vehicles = await _vehicleService.GetAllAsync();
        return Ok(vehicles);
    }
    /// <summary>
    /// Retorna um veículo específico pelo ID.
    /// </summary>
    /// <param name="id">ID do veículo.</param>
    /// <returns>Detalhes do veículo solicitado.</returns>
    /// <response code="200">Retorna o veículo com o ID fornecido.</response>
    /// <response code="404">Se o veículo não for encontrado.</response
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserResponse), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        var vehicle = await _vehicleService.GetByIdAsync(id);

        if (vehicle is null)
            return NotFound();
        
        return Ok(vehicle);
    }
    /// <summary>
    /// Cria um novo veículo.
    /// </summary>
    /// <param name="vehicleRequest">Dados da veículo a ser criado.</param>
    /// <returns>Confirmação da criação da veículo.</returns>
    /// <response code="200">veículo criado com sucesso.</response>
    /// <response code="400">Se a requisição estiver inválida.</response>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] VehicleCreateRequest vehicleRequest)
    {
        await _vehicleService.AddAsync(vehicleRequest);
        return Ok();
    }

    /// <summary>
    /// Atualiza os dados de um veículo específico.
    /// </summary>
    /// <param name="id">ID do veículo a ser atualizado.</param>
    /// <param name="vehicleRequest">Novos dados da veículo.</param>
    /// <returns>Confirmação da atualização.</returns>
    /// <response code="204">veículo atualizado com sucesso.</response>
    /// <response code="404">Se o veículo não for encontrado.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(int id, [FromBody]VehicleUpdateRequest vehicleRequest)
    {
        var response = await _vehicleService.UpdateAsync(id, vehicleRequest);

        if (response is false)
            return NotFound();

        return NoContent();
    }
    /// <summary>
    /// Exclui uma veículo específico.
    /// </summary>
    /// <param name="id">ID da veículo a ser excluído.</param>
    /// <returns>Confirmação da exclusão.</returns>
    /// <response code="204">veículo excluído com sucesso.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        await _vehicleService.DeleteAsync(id);
        return NoContent();
    }
}
