using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Services.Mappers;
using AutoInventoryPro.Views.Auth.Login;
using AutoInventoryPro.Views.User.Responses;

namespace AutoInventoryPro.Services.Services;

public class AuthService(IUserRepository userRepository) : IAuthService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<UserResponse> Login(LoginRequest request)
    {
       var user = await _userRepository.Login(request.Email, request.Password);

        if (user == null)
            return null;

       return user.ToResponse(); 
    }
}
