using System.ComponentModel.DataAnnotations;

namespace AutoInventoryPro.Views.Sale.Requests;

public class SaleUpdateRequest
{
    [DataType(DataType.DateTime, ErrorMessage = "Data inválida.")]
    public DateTime? DataSale { get; set; }
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço de venda deve ser maior que zero.")]
    public Decimal? SalePrice { get; set; }

}
