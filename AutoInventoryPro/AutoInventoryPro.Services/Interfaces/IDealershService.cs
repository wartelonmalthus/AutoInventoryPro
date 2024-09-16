using AutoInventoryPro.Views.Dealersh.Requests;
using AutoInventoryPro.Views.Dealersh.Responses;

namespace AutoInventoryPro.Services.Interfaces;

public interface IDealershService 
{
    Task<IEnumerable<DealershResponse>> GetAllAsync();
    Task<DealershResponse> GetByIdAsync(int id);
    Task AddAsync(DealershCreateRequest request);
    Task<bool> UpdateAsync(int id, DealershUpdateRequest request);
    Task DeleteAsync(int id);

}
