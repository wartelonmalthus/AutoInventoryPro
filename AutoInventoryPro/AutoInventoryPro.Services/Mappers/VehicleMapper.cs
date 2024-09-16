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
        IdVehicle = vehicle.Id,
        Description = vehicle.Description,
        VehicleModel = vehicle.VehicleModel,
        YearManufacture = vehicle.YearManufacture,
        Price = vehicle.Price,
        VehicleType = vehicle.VehicleType,
        FabricatorInfo = vehicle.Fabricator != null ? vehicle.Fabricator.ToInfo() : null
    };

    public static IEnumerable<VehicleResponse> ToResponse(this  IEnumerable<Vehicle> vehicles) => vehicles.Select(vehicle => vehicle.ToResponse());
}
