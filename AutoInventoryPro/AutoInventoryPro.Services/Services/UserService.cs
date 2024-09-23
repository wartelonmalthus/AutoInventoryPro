using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Infraestructure.Repositories;
using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Models.Enums;
using AutoInventoryPro.Services.Cache;
using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Services.Mappers;
using AutoInventoryPro.Views.User.Requests;
using AutoInventoryPro.Views.User.Responses;
using Microsoft.Extensions.Caching.Memory;

namespace AutoInventoryPro.Services.Services;

public class UserService(IUserRepository userRepository, IMemoryCache memoryCache, CacheOptionsProvider cacheOptionsProvider) : BaseService(memoryCache), IUserService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly CacheOptionsProvider _cacheOptionsProvider = cacheOptionsProvider;

    public async Task AddAsync(UserCreateRequest request)
    {
        ClearCache();
        await _userRepository.AddAsync(request.ToEntity()); 
    }

    public async Task DeleteAsync(int id) 
    {
        ClearCache();
        await _userRepository.DeleteAsync(id); 
    } 

    public async Task<IEnumerable<UserResponse>> GetAllAsync()
    {
        if (!_memoryCache.TryGetValue("users", out IEnumerable<User> users))
        {
            users = await _userRepository.GetAllAsync();
            _memoryCache.Set("users", users, _cacheOptionsProvider.GetCacheOptions());
            AddCacheKey("sales");
        }

        return users.ToResponse();
    }

    public async Task<UserResponse> GetByIdAsync(int id)
    {
        if (!_memoryCache.TryGetValue($"userId:{id}", out User user))
        {
            user = await _userRepository.GetByIdAsync(id);
            _memoryCache.Set($"userId:{id}", user, _cacheOptionsProvider.GetCacheOptions());
            AddCacheKey($"userId:{id}");
        }
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

        ClearCache();
        await _userRepository.UpdateAsync(user);    
        
        return true;

    }
}
