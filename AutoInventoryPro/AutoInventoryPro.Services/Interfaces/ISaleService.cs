using AutoInventoryPro.Views.Sale.Requests;
using AutoInventoryPro.Views.Sale.Responses;

namespace AutoInventoryPro.Services.Interfaces;

public interface ISaleService 
{
    Task<IEnumerable<SaleResponse>> GetAllAsync();
    Task<SaleResponse> GetByIdAsync(int id);
    Task AddAsync(SaleCreateRequest request);
    Task UpdateAsync(SaleUpdateRequest entity);
    Task DeleteAsync(int id);

}
