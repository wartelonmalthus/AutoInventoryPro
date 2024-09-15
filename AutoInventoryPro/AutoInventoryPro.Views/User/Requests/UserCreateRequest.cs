using AutoInventoryPro.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AutoInventoryPro.Views.User.Requests;

public class UserCreateRequest
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória.")]
    [StringLength(255, ErrorMessage = "A senha deve ter no máximo 255 caracteres.")]
    [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "O email é obrigatório.")]
    [EmailAddress(ErrorMessage = "O formato do email é inválido.")]
    [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O papel do usuário é obrigatório.")]
    [EnumDataType(typeof(EUserRoles), ErrorMessage = "O valor do papel do usuário é inválido.")]
    public EUserRoles UserRole { get; set; }
}
