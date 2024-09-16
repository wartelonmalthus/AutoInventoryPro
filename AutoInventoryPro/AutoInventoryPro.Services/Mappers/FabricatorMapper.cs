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
        IdFabricator = fabricator.Id,
        Name = fabricator.Name,
        Country = fabricator.Country,
        WebSite = fabricator.WebSite,
        YearFoundation = fabricator.YearFoundation,
        vehicleResponses = fabricator.Vehicles != null ? fabricator.Vehicles.ToResponse() : null
    };

    public static FabricatorInfo ToInfo(this Fabricator fabricator) => new() 
    {
        IdFabricator = fabricator.Id,
        Name = fabricator.Name
        
    };

    public static IEnumerable<FabricatorResponse> ToResponse(this IEnumerable<Fabricator> fabricators) => fabricators.Select(fabricator => fabricator.ToResponse());

}
