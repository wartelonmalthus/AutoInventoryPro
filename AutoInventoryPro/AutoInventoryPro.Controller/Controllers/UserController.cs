using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Views.User.Requests;
using AutoInventoryPro.Views.User.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AutoInventoryPro.Controllers.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    /// <summary>
    /// Retorna uma lista de todss os usuários.
    /// </summary>
    /// <returns>Uma lista de usuários.</returns>
    /// <response code="200">Retorna a lista de usuários.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UserResponse>), 200)]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<UserResponse> users = await _userService.GetAllAsync();
        return Ok(users);
    }

    /// <summary>
    /// Retorna um usuário específico pelo ID.
    /// </summary>
    /// <param name="id">ID do usuário.</param>
    /// <returns>Detalhes do usuário solicitado.</returns>
    /// <response code="200">Retorna o usuário com o ID fornecido.</response>
    /// <response code="404">Se o usuário não for encontrado.</response
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserResponse), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        UserResponse user = await _userService.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
    /// <summary>
    /// Cria um novo usuário.
    /// </summary>
    /// <param name="userRequest">Dados da usuário a ser criado.</param>
    /// <returns>Confirmação da criação da usuário.</returns>
    /// <response code="200">usuário criado com sucesso.</response>
    /// <response code="400">Se a requisição estiver inválida.</response>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] UserCreateRequest userRequest)
    {
        await _userService.AddAsync(userRequest);
        return Ok();
    }

    /// <summary>
    /// Atualiza os dados de um usuário específico.
    /// </summary>
    /// <param name="id">ID do usuário a ser atualizado.</param>
    /// <param name="userRequest">Novos dados da usuário.</param>
    /// <returns>Confirmação da atualização.</returns>
    /// <response code="204">usuário atualizado com sucesso.</response>
    /// <response code="404">Se o usuário não for encontrado.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(int id, [FromBody] UserUpdateRequest userRequest)
    {
        var response = await _userService.UpdateAsync(id,userRequest);

        if (response is false)
            return NotFound();

        return NoContent();
    }
    /// <summary>
    /// Exclui uma usuário específico.
    /// </summary>
    /// <param name="id">ID da usuário a ser excluído.</param>
    /// <returns>Confirmação da exclusão.</returns>
    /// <response code="204">usuário excluído com sucesso.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.DeleteAsync(id);
        return NoContent();
    }
}
