using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Models.Enums;
using AutoInventoryPro.Services.Cache;
using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Services.Mappers;
using AutoInventoryPro.Views.Vehicle.Requests;
using AutoInventoryPro.Views.Vehicle.Responses;
using Microsoft.Extensions.Caching.Memory;

namespace AutoInventoryPro.Services.Services;

public class VehicleService(IVehicleRepository vehicleRepository, IMemoryCache memoryCache, CacheOptionsProvider cacheOptionsProvider) : BaseService(memoryCache), IVehicleService
{
    private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
    private readonly CacheOptionsProvider _cacheOptionsProvider = cacheOptionsProvider;

    public async Task AddAsync(VehicleCreateRequest request)
    {
        ClearCache();
        await _vehicleRepository.AddAsync(request.ToEntity());
    }

    public async Task DeleteAsync(int id) 
    {
        ClearCache();
        await _vehicleRepository.DeleteAsync(id);    
    }

    public async Task<IEnumerable<VehicleResponse>> GetAllAsync()
    {
        if (!_memoryCache.TryGetValue("vehicles", out IEnumerable<Vehicle> vehicles))
        {
             vehicles = await _vehicleRepository.GetAllAsync();
            _memoryCache.Set("vehicles", vehicles, _cacheOptionsProvider.GetCacheOptions());
             AddCacheKey("vehicles");
        }

        return vehicles.ToResponse();
  
    }

    public async Task<VehicleResponse> GetByIdAsync(int id)
    {
        if (!_memoryCache.TryGetValue($"vehicleId:{id}", out  Vehicle vehicle))
        {
             vehicle = await _vehicleRepository.GetByIdAsync(id);
            _memoryCache.Set($"vehicleId:{id}", vehicle, _cacheOptionsProvider.GetCacheOptions());
            AddCacheKey($"vehicleId:{id}");
        }
        return vehicle.ToResponse();
    }

    public async Task<bool> UpdateAsync(int id, VehicleUpdateRequest request)
    {
        Vehicle? vehicle = await _vehicleRepository.GetByIdAsync(id);

        if (vehicle is null)
            return false;

        if (request.YearManufacture is not null) vehicle.YearManufacture = (int)request.YearManufacture;

        if (request.VehicleModel is not null) vehicle.VehicleModel = request.VehicleModel;

        if (request.VehicleType is not null) vehicle.VehicleType = (EVehicleType)request.VehicleType;

        if(request.IdFabricator is not null) vehicle.IdFabricator = (int) request.IdFabricator;
        
        if(request.Description is not null) vehicle.Description = request.Description;

        vehicle.UpdatedAt= DateTime.Now;

        ClearCache();
        await _vehicleRepository.UpdateAsync(vehicle);
       
        return true;
    }
}
