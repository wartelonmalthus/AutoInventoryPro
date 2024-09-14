using AutoInventoryPro.Models.Enums;

namespace AutoInventoryPro.Models.Entities;

public class User : BaseEntity
{
    /// <summary>
    /// Nome de usuário.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Senha criptografada.
    /// </summary>
    public string Password { get; set; }
    /// <summary>
    /// Email do usuário.
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// Nível de acesso do usuário: Administrador,Vendedor,Gerente
    /// </summary>
    public EUserRoles UserRole { get; set; }

}
