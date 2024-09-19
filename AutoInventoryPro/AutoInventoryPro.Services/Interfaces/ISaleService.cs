using AutoInventoryPro.Views.Sale.Requests;
using AutoInventoryPro.Views.Sale.Responses;

namespace AutoInventoryPro.Services.Interfaces;

public interface ISaleService 
{
    Task<IEnumerable<SaleResponse>> GetAllAsync();
    Task<SaleResponse> GetByIdAsync(int id);
    Task<bool> AddAsync(SaleCreateRequest request);
    Task<bool> UpdateAsync(int id, SaleUpdateRequest request);
    Task DeleteAsync(int id);

}
