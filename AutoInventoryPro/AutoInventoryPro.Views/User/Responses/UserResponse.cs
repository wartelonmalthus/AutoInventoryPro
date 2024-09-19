using AutoInventoryPro.Models.Enums;

namespace AutoInventoryPro.Views.User.Responses;

public class UserResponse
{
    public int IdUser { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string UserRole { get; set; }
}
