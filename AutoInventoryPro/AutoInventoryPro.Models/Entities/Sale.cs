namespace AutoInventoryPro.Models.Entities;

public class Sale : BaseEntity
{
    /// <summary>
    /// Referência à concessionária onde a venda foi realizada.
    /// </summary>
    public int IdDealersh{ get; set; }
    /// <summary>
    /// Referência ao veículo vendido.
    /// </summary>
    public int IdVehicle { get; set; }
    /// <summary>
    /// Referência ao cliente que realizou a compra.
    /// </summary>
    public int IdClient { get; set; }
    /// <summary>
    /// Data e hora da venda.
    /// </summary>
    public DateTime DataSale { get; set; }
    /// <summary>
    /// Preço final de venda do veículo.
    /// </summary>
    public Decimal SalePrice { get; set; }
    /// <summary>
    /// Número de protocolo único para a venda.
    /// </summary>
    public Guid SaleProtocol { get; set; }

    // Relacionamentos EF
    public Vehicle Vehicle { get; set; } 
    public Dealersh Dealersh { get; set; }
    public Client Client { get; set; }

}
