using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Views.Sale.Requests;
using AutoInventoryPro.Views.Sale.Responses;

namespace AutoInventoryPro.Services.Services;

public class SaleService(ISaleRepository saleRepository) : ISaleService
{
    private readonly ISaleRepository _saleRepository = saleRepository;

    public Task AddAsync(SaleCreateRequest request)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SaleResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<SaleResponse> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(SaleUpdateRequest entity)
    {
        throw new NotImplementedException();
    }
}
