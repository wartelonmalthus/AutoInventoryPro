using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Views.Dealersh.Requests;
using AutoInventoryPro.Views.Dealersh.Responses;

namespace AutoInventoryPro.Services.Services;

public class DealershService(IDealershRepository dealershRepository) : IDealershService
{
    private readonly IDealershRepository _dealershRepository = dealershRepository;

    public Task AddAsync(DealershCreateRequest request)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DealershResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<DealershResponse> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(DealershUpdateRequest entity)
    {
        throw new NotImplementedException();
    }
}
