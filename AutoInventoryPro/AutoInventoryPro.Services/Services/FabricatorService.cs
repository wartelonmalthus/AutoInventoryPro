using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Services.Cache;
using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Services.Mappers;
using AutoInventoryPro.Views.Fabricator.Requests;
using AutoInventoryPro.Views.Fabricator.Responses;
using Microsoft.Extensions.Caching.Memory;
namespace AutoInventoryPro.Services.Services;
public class FabricatorService(IFabricatorRepository fabricatorRepository, IMemoryCache memoryCache, CacheOptionsProvider cacheOptionsProvider) : BaseService(memoryCache), IFabricatorService
{
    private readonly IFabricatorRepository _fabricatorRepository = fabricatorRepository;
    private readonly CacheOptionsProvider _cacheOptionsProvider = cacheOptionsProvider;

    public async Task AddAsync(FabricatorCreateRequest request)
    {
        ClearCache();
        await _fabricatorRepository.AddAsync(request.ToEntity());
       
    }

    public async Task DeleteAsync(int id)
    {
        ClearCache();
        await  _fabricatorRepository.DeleteAsync(id);       
    } 

    public async Task<IEnumerable<FabricatorResponse>> GetAllAsync()
    {
        if (!_memoryCache.TryGetValue("fabricators", out IEnumerable<Fabricator> fabricators))
        {
            fabricators = await _fabricatorRepository.GetAllAsync();
            _memoryCache.Set("fabricators", fabricators, _cacheOptionsProvider.GetCacheOptions());
            AddCacheKey("fabricators");
        }

        return fabricators.ToResponse();
    }

    public async Task<FabricatorResponse> GetByIdAsync(int id)
    {
        if (!_memoryCache.TryGetValue($"fabricatorId:{id}", out Fabricator fabricator))
        {
            fabricator = await _fabricatorRepository.GetByIdAsync(id);
            _memoryCache.Set($"fabricatorId:{id}", fabricator, _cacheOptionsProvider.GetCacheOptions());
            AddCacheKey($"fabricatorId:{id}");
        }
        return fabricator.ToResponse();
    }

    public async Task<bool> UpdateAsync(int id, FabricatorUpdateRequest request)
    {
        Fabricator? fabricator = await _fabricatorRepository.GetByIdAsync(id);

        if (fabricator is null)
            return false;

        if (request.WebSite is not null) fabricator.WebSite = request.WebSite;

        if (request.YearFoundation is not null) fabricator.YearFoundation = (int)request.YearFoundation;

        if (request.Country is not null) fabricator.Country = request.Country;

        if(request.Name is not null) fabricator.Name = request.Name;

        fabricator.UpdatedAt= DateTime.Now;

        ClearCache();
        await _fabricatorRepository.UpdateAsync(fabricator);
      
        return true;
    }
}
