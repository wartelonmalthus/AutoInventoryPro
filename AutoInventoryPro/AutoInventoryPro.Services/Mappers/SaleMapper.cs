using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Views.Sale.Requests;
using AutoInventoryPro.Views.Sale.Responses;

namespace AutoInventoryPro.Services.Mappers;

public static class SaleMapper
{
    public static Sale ToEntity(this SaleCreateRequest request) => new() 
    {
        DataSale= request.DataSale,
        IdClient= request.IdClient,
        IdDealersh = request.IdDealersh,
        IdVehicle = request.IdVehicle,
        SalePrice = request.SalePrice,
        SaleProtocol = Guid.NewGuid().ToString("N").Substring(0, 20)
    };

    public static SaleResponse ToResponse(this Sale sale) => new()
    {
        IdSale = sale.Id,
        SaleProtocol= sale.SaleProtocol,
        SalePrice= sale.SalePrice,
        DataSale= sale.DataSale,
        Client = sale.Client != null ? sale.Client.ToResponse() : null,
        Dealersh = sale.Client != null ? sale.Dealersh.ToResponse() : null,
        Vehicle = sale.Client != null ? sale.Vehicle.ToResponse() : null    
    };

    public static IEnumerable<SaleResponse>ToResponse(this IEnumerable<Sale> sales) => sales.Select(sale => sale.ToResponse());
}
