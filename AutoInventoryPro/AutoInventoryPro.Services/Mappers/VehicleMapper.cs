using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Views.Vehicle.Requests;
using AutoInventoryPro.Views.Vehicle.Responses;

namespace AutoInventoryPro.Services.Mappers;

public static class VehicleMapper
{

    public static Vehicle ToEntity(this VehicleCreateRequest request) => new() 
    { 
        IdFabricator = request.IdFabricator,
        Price = request.Price,
        VehicleModel = request.VehicleModel,
        VehicleType = request.VehicleType,
        YearManufacture = request.YearManufacture,
        Description = request.Description
        
    };


    public static VehicleResponse ToResponse(this Vehicle vehicle) => new() 
    {
        Description = vehicle.Description,
        VehicleModel = vehicle.VehicleModel,
        YearManufacture = vehicle.YearManufacture,
        Price = vehicle.Price,
        VehicleType = vehicle.VehicleType,
        FabricatorResponse = vehicle.Fabricator.ToResponse()
    };

    public static IEnumerable<VehicleResponse> ToResponse(this  IEnumerable<Vehicle> vehicles) => vehicles.Select(vehicles => vehicles.ToResponse());
}
