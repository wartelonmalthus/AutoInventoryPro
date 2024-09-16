using AutoInventoryPro.Views.Client.Responses;
using AutoInventoryPro.Views.Dealersh.Responses;
using AutoInventoryPro.Views.Vehicle.Responses;

namespace AutoInventoryPro.Views.Sale.Responses;

public class SaleResponse
{
    public int IdSale { get; set; }
    public DateTime DataSale { get; set; }
    public Decimal SalePrice { get; set; }
    public string SaleProtocol { get; set; }
    public VehicleResponse Vehicle { get; set; }
    public DealershResponse Dealersh { get; set; }
    public ClientResponse Client { get; set; }
    

}
