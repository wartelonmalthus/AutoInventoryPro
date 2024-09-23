using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Services.Cache;
using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Services.Mappers;
using AutoInventoryPro.Views.Dealersh.Requests;
using AutoInventoryPro.Views.Dealersh.Responses;
using Microsoft.Extensions.Caching.Memory;

namespace AutoInventoryPro.Services.Services;

public class DealershService(IDealershRepository dealershRepository, IMemoryCache memoryCache, CacheOptionsProvider cacheOptionsProvider) : BaseService(memoryCache), IDealershService
{
    private readonly IDealershRepository _dealershRepository = dealershRepository;
    private readonly CacheOptionsProvider _cacheOptionsProvider = cacheOptionsProvider;

    public async  Task AddAsync(DealershCreateRequest request)
    {
        ClearCache();
        await _dealershRepository.AddAsync(request.ToEntity());
       
    }

    public async Task DeleteAsync(int id)
    {
        ClearCache();
        await _dealershRepository.DeleteAsync(id);
       
    } 

    public async Task<IEnumerable<DealershResponse>> GetAllAsync()
    {
        if (!_memoryCache.TryGetValue("dealershs", out IEnumerable<Dealersh> dealershs))
        {
            dealershs = await _dealershRepository.GetAllAsync();
            _memoryCache.Set("dealershs", dealershs, _cacheOptionsProvider.GetCacheOptions());
            AddCacheKey("dealershs");
        }

        return dealershs.ToResponse();
    }

    public async Task<DealershResponse> GetByIdAsync(int id)
    {
        if (!_memoryCache.TryGetValue($"dealershId:{id}", out Dealersh dealersh))
        {
            dealersh = await _dealershRepository.GetByIdAsync(id);
            _memoryCache.Set($"dealershId:{id}", dealersh, _cacheOptionsProvider.GetCacheOptions());
            AddCacheKey($"dealershId:{id}");
        }
        return dealersh.ToResponse();
    }

    public async Task<bool> UpdateAsync(int id, DealershUpdateRequest request)
    {
        Dealersh? dealersh = await _dealershRepository.GetByIdAsync(id);

        if (dealersh is null)
            return false;

        if (request.Address is not null) dealersh.Address = request.Address;

        if (request.Name is not null) dealersh.Name = request.Name;

        if (request.PostalCode is not null) dealersh.PostalCode = request.PostalCode;

        if (request.City is not null) dealersh.City = request.City;

        if(request.Region is not null) dealersh.Region = request.Region;

        if(request.Email is not null) dealersh.Email = request.Email;

        if(request.Phone is not null) dealersh.Phone = request.Phone;

        if(request.MaximumCapacityVehicles is not null)dealersh.MaximumCapacityVehicles = (int)request.MaximumCapacityVehicles;

        dealersh.UpdatedAt = DateTime.Now;

        ClearCache();
        await _dealershRepository.UpdateAsync(dealersh);
      
        return true;
    }
}
