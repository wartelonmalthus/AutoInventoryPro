using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Models.Enums;
using AutoInventoryPro.Views.User.Requests;
using AutoInventoryPro.Views.User.Responses;

namespace AutoInventoryPro.Services.Mappers;

public static class UserMapper
{
    public static UserResponse ToResponse(this User user) => new()
    {
        Email = user.Email,
        Name = user.Name,
        UserRole = user.UserRole
        
    };

    public static User ToEntity(this UserCreateRequest request) => new()
    {
        Email = request.Email,
        Name = request.Name,
        UserRole = request.UserRole,
        Password = request.Password
           
    };

    public static User ToEntity(this UserUpdateRequest request) => new()
    {
        Email = request.Email,
        Name = request.Name,
        UserRole = (EUserRoles)request.UserRole,
        Password = request.Password,
        UpdatedAt = DateTime.Now

    };

}
