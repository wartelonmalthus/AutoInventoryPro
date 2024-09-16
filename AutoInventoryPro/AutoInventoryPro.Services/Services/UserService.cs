using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Models.Enums;
using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Services.Mappers;
using AutoInventoryPro.Views.User.Requests;
using AutoInventoryPro.Views.User.Responses;

namespace AutoInventoryPro.Services.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task AddAsync(UserCreateRequest request)
    {
        var user = request.ToEntity();
        await _userRepository.AddAsync(user);
    }

    public Task DeleteAsync(int id) => _userRepository.DeleteAsync(id);

    public async Task<IEnumerable<UserResponse>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.ToResponse();
    }

    public async Task<UserResponse> GetByIdAsync(int id)
    {
       var user = await _userRepository.GetByIdAsync(id);
       return user.ToResponse();
    }

    public async Task<bool> UpdateAsync(int id, UserUpdateRequest entity)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user is null)
            return false;

        if(entity.UserRole is not null) user.UserRole = (EUserRoles)entity.UserRole;

        if(entity.Name is not null) user.Name = entity.Name;

        if(entity.Email is not null) user.Email = entity.Email;

        user.UpdatedAt= DateTime.Now;

        await _userRepository.UpdateAsync(user);      
        return true;

    }
}
