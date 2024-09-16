using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Models.Enums;
using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Services.Mappers;
using AutoInventoryPro.Views.Vehicle.Requests;
using AutoInventoryPro.Views.Vehicle.Responses;

namespace AutoInventoryPro.Services.Services;

public class VehicleService(IVehicleRepository vehicleRepository) : IVehicleService
{
    private readonly IVehicleRepository _vehicleRepository = vehicleRepository;

    public async Task AddAsync(VehicleCreateRequest request)
    {
        var vehicle = request.ToEntity();
        await _vehicleRepository.AddAsync(vehicle);
    }

    public Task DeleteAsync(int id) => _vehicleRepository.DeleteAsync(id);

    public async Task<IEnumerable<VehicleResponse>> GetAllAsync()
    {
        var vehicles = await _vehicleRepository.GetAllAsync();
        return vehicles.ToResponse();
    }

    public async Task<VehicleResponse> GetByIdAsync(int id)
    {
        var vehicle = await _vehicleRepository.GetByIdDetailAsync(id);
        return vehicle.ToResponse();
    }

    public async Task<bool> UpdateAsync(int id, VehicleUpdateRequest request)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(id);

        if (vehicle is null)
            return false;

        if (request.YearManufacture is not null) vehicle.YearManufacture = (int)request.YearManufacture;

        if (request.VehicleModel is not null) vehicle.VehicleModel = request.VehicleModel;

        if (request.VehicleType is not null) vehicle.VehicleType = (EVehicleType)request.VehicleType;

        if(request.IdFabricator is not null) vehicle.IdFabricator = (int) request.IdFabricator;
        
        if(request.Description is not null) vehicle.Description = request.Description;

        vehicle.UpdatedAt= DateTime.Now;

        await _vehicleRepository.UpdateAsync(vehicle);
        return true;
    }
}
