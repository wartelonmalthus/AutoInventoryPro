namespace AutoInventoryPro.Models.Entities;

public class Dealersh : BaseEntity
{
    /// <summary>
    /// Nome da concessionária
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Endereço completo da concessionária.
    /// </summary>
    public string Address { get; set; }
    /// <summary>
    /// Cidade onde a concessionária está localizada.
    /// </summary>
    public string City { get; set; }
    /// <summary>
    /// Estado onde a concessionária está localizada.
    /// </summary>
    public string Region { get; set; }
    /// <summary>
    /// CEP da concessionária.
    /// </summary>
    public string PostalCode { get; set; }
    /// <summary>
    /// Email de contato.
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// Telefone de contato.
    /// </summary>
    public string Phone { get; set; }
    /// <summary>
    /// Capacidade máxima de veículos que a concessionária pode armazenar.
    /// </summary>
    public int MaximumCapacityVehicles { get; set; }

    // Relacionamento EF
    public virtual HashSet<Sale> Sales { get; set; } = new HashSet<Sale>();

}
