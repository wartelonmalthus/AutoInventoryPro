using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Views.Fabricator.Requests;
using AutoInventoryPro.Views.Fabricator.Responses;

namespace AutoInventoryPro.Services.Services;

public class FabricatorService(IFabricatorRepository fabricatorRepository) : IFabricatorService
{
    private readonly IFabricatorRepository _fabricatorRepository = fabricatorRepository;

    public Task AddAsync(FabricatorCreateRequest request)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<FabricatorResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<FabricatorResponse> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(FabricatorUpdateRequest entity)
    {
        throw new NotImplementedException();
    }
}
