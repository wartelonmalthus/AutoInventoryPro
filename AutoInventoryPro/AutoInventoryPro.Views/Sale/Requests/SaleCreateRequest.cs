using System.ComponentModel.DataAnnotations;

namespace AutoInventoryPro.Views.Sale.Requests;

public class SaleCreateRequest
{
    [Required(ErrorMessage = "O campo IdDealersh é obrigatório.")]
    public int IdDealersh { get; set; }

    [Required(ErrorMessage = "O campo IdVehicle é obrigatório.")]
    public int IdVehicle { get; set; }

    [Required(ErrorMessage = "O campo IdClient é obrigatório.")]
    public int IdClient { get; set; }

    [Required(ErrorMessage = "O campo DataSale é obrigatório.")]
    [DataType(DataType.DateTime, ErrorMessage = "Data inválida.")]
    public DateTime DataSale { get; set; }

    [Required(ErrorMessage = "O campo SalePrice é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço de venda deve ser maior que zero.")]
    public Decimal SalePrice { get; set; }

}
