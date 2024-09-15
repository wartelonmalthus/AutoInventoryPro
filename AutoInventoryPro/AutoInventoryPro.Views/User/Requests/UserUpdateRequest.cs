using AutoInventoryPro.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AutoInventoryPro.Views.User.Requests;

public class UserUpdateRequest
{
    [StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
    public string? Name { get; set; }

    [StringLength(255, ErrorMessage = "A senha deve ter no máximo 255 caracteres.")]
    [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
    public string? Password { get; set; }

    [EmailAddress(ErrorMessage = "O formato do email é inválido.")]
    [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres.")]
    public string? Email { get; set; }

    [EnumDataType(typeof(EUserRoles), ErrorMessage = "O valor do papel do usuário é inválido.")]
    public EUserRoles? UserRole { get; set; }
}
