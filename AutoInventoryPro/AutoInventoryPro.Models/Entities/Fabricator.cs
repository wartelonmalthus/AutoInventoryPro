namespace AutoInventoryPro.Models.Entities;

public class Fabricator : BaseEntity
{
    /// <summary>
    /// Nome do fabricante
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// País de origem do fabricante.
    /// </summary>
    public string Country { get; set; }
    /// <summary>
    /// Ano de fundação do fabricante.
    /// </summary>
    public int YearFoundation { get; set; }
    /// <summary>
    /// URL do site do fabricante.
    /// </summary>
    public string WebSite { get; set; }

    // Relacionamento EF
    public HashSet<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();

}
