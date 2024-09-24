using AutoInventoryPro.Views.Auth.Login;
using AutoInventoryPro.Views.User.Responses;

namespace AutoInventoryPro.Services.Interfaces;

public interface IAuthService
{
    Task<UserResponse> Login(LoginRequest request);
}
