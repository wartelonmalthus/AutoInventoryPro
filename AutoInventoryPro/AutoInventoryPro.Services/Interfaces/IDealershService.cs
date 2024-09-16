using AutoInventoryPro.Views.Dealersh.Requests;
using AutoInventoryPro.Views.Dealersh.Responses;

namespace AutoInventoryPro.Services.Interfaces;

public interface IDealershService 
{
    Task<IEnumerable<DealershResponse>> GetAllAsync();
    Task<DealershResponse> GetByIdAsync(int id);
    Task AddAsync(DealershCreateRequest request);
    Task UpdateAsync(DealershUpdateRequest entity);
    Task DeleteAsync(int id);

}
