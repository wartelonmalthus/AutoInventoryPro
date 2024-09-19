using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Views.Auth.Login;
using Microsoft.AspNetCore.Mvc;

namespace AutoInventoryPro.Controllers.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var response = await _authService.Login(request);
        if(response == null)
        {
            return NotFound();
        }
        return Ok(response);
    }
}
