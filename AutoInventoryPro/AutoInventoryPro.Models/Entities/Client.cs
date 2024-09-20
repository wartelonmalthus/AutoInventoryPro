namespace AutoInventoryPro.Models.Entities;

public class Client : BaseEntity
{
    /// <summary>
    /// Nome completo do cliente.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// CPF do cliente.
    /// </summary>
    public string CPF { get; set; }
    /// <summary>
    /// Telefone de contato do cliente.
    /// </summary>
    public string Phone { get; set; }

    // Relacionamento EF
    public virtual HashSet<Sale> Sales { get; set; } = new HashSet<Sale>();

}
