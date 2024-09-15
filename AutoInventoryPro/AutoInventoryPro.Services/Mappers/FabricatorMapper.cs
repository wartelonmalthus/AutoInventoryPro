using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Views.Fabricator.Requests;
using AutoInventoryPro.Views.Fabricator.Responses;

namespace AutoInventoryPro.Services.Mappers;

public static class FabricatorMapper
{
    public static Fabricator ToEntity(this FabricatorCreateRequest request) => new()
    {
        Name = request.Name,
        Country = request.Country,
        WebSite = request.WebSite,
        YearFoundation= request.YearFoundation,
        
    };

    public static FabricatorResponse ToResponse(this Fabricator fabricator) => new()
    {
        Name = fabricator.Name,
        Country = fabricator.Country,
        WebSite = fabricator.WebSite,
        YearFoundation = fabricator.YearFoundation,
        vehicleResponses = fabricator.Vehicles.ToResponse()
    };
}
