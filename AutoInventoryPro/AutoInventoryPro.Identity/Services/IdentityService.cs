using AutoInventoryPro.Identity.Configurations;
using AutoInventoryPro.Identity.Interfaces;
using AutoInventoryPro.Identity.Requests;
using AutoInventoryPro.Identity.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;


namespace AutoInventoryPro.Identity.Services;

internal class IdentityService(SignInManager<IdentityUser> signInManager,
                           UserManager<IdentityUser> userManager,
                           IOptions<JwtOptions> jwtOptions) : IIdentityService
{
    private readonly SignInManager<IdentityUser> _signInManager = signInManager;
    private readonly UserManager<IdentityUser> _userManager = userManager;
    private readonly JwtOptions _jwtOptions = jwtOptions.Value;

    public Task<LoginResponse> Login(LoginRequestIdentity request)
    {
        throw new NotImplementedException();
    }
}
