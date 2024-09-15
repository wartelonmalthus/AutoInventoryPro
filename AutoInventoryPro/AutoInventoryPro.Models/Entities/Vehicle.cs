using AutoInventoryPro.Models.Enums;

namespace AutoInventoryPro.Models.Entities;

public class Vehicle : BaseEntity
{
    /// <summary>
    /// Nome do modelo do veículo.
    /// </summary>
    public string VehicleModel { get; set; }
    /// <summary>
    /// Ano de fabricação do veículo.
    /// </summary>
    public int YearManufacture { get; set; }
    /// <summary>
    /// Preço do veículo.
    /// </summary>
    public decimal Price { get; set; }
    /// <summary>
    ///  Chave estrangeira para a tabela fabricantes.
    /// </summary>
    public int IdFabricator { get; set; }
    /// <summary>
    /// Tipo de veículo.
    /// </summary>
    public EVehicleType VehicleType {  get; set; }
    /// <summary>
    /// Descrição opcional do veículo.
    /// </summary>
    public string? Description { get; set; }


    // Relacionamentos EF
    public Fabricator Fabricator { get; set; }
    public HashSet<Sale> Sales { get; set; } = new HashSet<Sale>();


}
