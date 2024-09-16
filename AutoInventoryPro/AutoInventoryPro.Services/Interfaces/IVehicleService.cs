using AutoInventoryPro.Views.Vehicle.Requests;
using AutoInventoryPro.Views.Vehicle.Responses;

namespace AutoInventoryPro.Services.Interfaces;

public interface IVehicleService 
{
    Task<IEnumerable<VehicleResponse>> GetAllAsync();
    Task<VehicleResponse> GetByIdAsync(int id);
    Task AddAsync(VehicleCreateRequest request);
    Task<bool> UpdateAsync(int id, VehicleUpdateRequest request);
    Task DeleteAsync(int id);
}
