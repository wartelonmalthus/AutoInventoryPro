using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Views.Auth.Login;
using AutoInventoryPro.Views.User.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AutoInventoryPro.Controllers.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    /// <summary>
    /// Autenticação usuario no banco
    /// </summary>
    /// <returns>Retorna o usuario online</returns>
    [HttpPost]
    [ProducesResponseType(typeof(UserResponse), 201)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        UserResponse response = await _authService.Login(request);
        if(response == null)
        {
            return NotFound();
        }
        return Ok(response);
    }
}
