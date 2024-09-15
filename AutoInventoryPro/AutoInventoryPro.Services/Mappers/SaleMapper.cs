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
        SaleProtocol = request.SaleProtocol    
    };

    public static SaleResponse ToResponse(this Sale sale) => new()
    {
        Client = sale.Client.ToResponse(),
        SaleProtocol= sale.SaleProtocol,
        SalePrice= sale.SalePrice,
        DataSale= sale.DataSale,
        Dealersh = sale.Dealersh.ToResponse(),
        Vehicle = sale.Vehicle.ToResponse()    
    };

    public static IEnumerable<SaleResponse>ToResponse(this IEnumerable<Sale> sales) => sales.Select(sales => sales.ToResponse());
}
