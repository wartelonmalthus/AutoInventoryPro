using System.ComponentModel.DataAnnotations;

namespace AutoInventoryPro.Views.Identity.Login.Requests;

public class LoginRequestIdentity
{
    [Required(ErrorMessage = "O Email é obrigatório.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A Senha é obrigatório.")]
    public string Password { get; set; }
}

