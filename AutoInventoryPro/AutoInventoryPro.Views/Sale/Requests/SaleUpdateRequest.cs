using System.ComponentModel.DataAnnotations;

namespace AutoInventoryPro.Views.Sale.Requests;

public class SaleUpdateRequest
{
    public int? IdDealersh { get; set; }
    public int? IdVehicle { get; set; }
    public int? IdClient { get; set; }
    [DataType(DataType.DateTime, ErrorMessage = "Data inválida.")]
    public DateTime? DataSale { get; set; }
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço de venda deve ser maior que zero.")]
    public Decimal? SalePrice { get; set; }
    [Required(ErrorMessage = "O campo SaleProtocol é obrigatório.")]
    public Guid? SaleProtocol { get; set; }
}
