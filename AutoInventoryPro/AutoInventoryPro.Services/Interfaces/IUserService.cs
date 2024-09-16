using AutoInventoryPro.Views.User.Requests;
using AutoInventoryPro.Views.User.Responses;

namespace AutoInventoryPro.Services.Interfaces;

public interface IUserService 
{
    Task<IEnumerable<UserResponse>> GetAllAsync();
    Task<UserResponse> GetByIdAsync(int id);
    Task AddAsync(UserCreateRequest request);
    Task<bool> UpdateAsync(int id, UserUpdateRequest entity);
    Task DeleteAsync(int id);
}
