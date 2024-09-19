using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Views.User.Requests;
using AutoInventoryPro.Views.User.Responses;

namespace AutoInventoryPro.Services.Mappers;

public static class UserMapper
{
    public static UserResponse ToResponse(this User user) => new()
    {
        IdUser = user.Id,
        Email = user.Email,
        Name = user.Name,
        UserRole = user.UserRole.ToString(),
        
    };

    public static User ToEntity(this UserCreateRequest request) => new()
    { 
        Email = request.Email,
        Name = request.Name,
        UserRole = request.UserRole,
        Password = request.Password    
    };

    public static IEnumerable<UserResponse> ToResponse(this IEnumerable<User> users) => users.Select(user => user.ToResponse());

}
