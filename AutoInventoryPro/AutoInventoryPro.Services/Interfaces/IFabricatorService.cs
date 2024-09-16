using AutoInventoryPro.Views.Fabricator.Requests;
using AutoInventoryPro.Views.Fabricator.Responses;

namespace AutoInventoryPro.Services.Interfaces;

public interface IFabricatorService 
{
    Task<IEnumerable<FabricatorResponse>> GetAllAsync();
    Task<FabricatorResponse> GetByIdAsync(int id);
    Task AddAsync(FabricatorCreateRequest request);
    Task UpdateAsync(FabricatorUpdateRequest entity);
    Task DeleteAsync(int id);
}
