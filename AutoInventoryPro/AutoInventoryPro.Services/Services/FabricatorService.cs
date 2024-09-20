using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Services.Mappers;
using AutoInventoryPro.Views.Fabricator.Requests;
using AutoInventoryPro.Views.Fabricator.Responses;

namespace AutoInventoryPro.Services.Services;

public class FabricatorService(IFabricatorRepository fabricatorRepository) : IFabricatorService
{
    private readonly IFabricatorRepository _fabricatorRepository = fabricatorRepository;

    public async Task AddAsync(FabricatorCreateRequest request)
    {
        var fabricator = request.ToEntity();
        await _fabricatorRepository.AddAsync(fabricator);
    }

    public Task DeleteAsync(int id) => _fabricatorRepository.DeleteAsync(id);

    public async Task<IEnumerable<FabricatorResponse>> GetAllAsync()
    {
        var fabricators = await _fabricatorRepository.GetAllAsync();
        return fabricators.ToResponse();
    }

    public async Task<FabricatorResponse> GetByIdAsync(int id)
    {
        var fabricator = await _fabricatorRepository.GetByIdAsync(id); 
        return fabricator.ToResponse();
    }

    public async Task<bool> UpdateAsync(int id, FabricatorUpdateRequest request)
    {
        var fabricator = await _fabricatorRepository.GetByIdAsync(id);

        if (fabricator is null)
            return false;

        if (request.WebSite is not null) fabricator.WebSite = request.WebSite;

        if (request.YearFoundation is not null) fabricator.YearFoundation = (int)request.YearFoundation;

        if (request.Country is not null) fabricator.Country = request.Country;

        if(request.Name is not null) fabricator.Name = request.Name;

        fabricator.UpdatedAt= DateTime.Now;

        await _fabricatorRepository.UpdateAsync(fabricator);
        return true;
    }
}
