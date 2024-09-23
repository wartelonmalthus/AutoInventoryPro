using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Services.Cache;
using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Services.Mappers;
using AutoInventoryPro.Views.Sale.Requests;
using AutoInventoryPro.Views.Sale.Responses;
using Microsoft.Extensions.Caching.Memory;
namespace AutoInventoryPro.Services.Services;

public class SaleService(ISaleRepository saleRepository, IDealershRepository dealershRepository,
                         IClientRepository clientRepository, IVehicleRepository vehicleRepository,
                         IMemoryCache memoryCache, CacheOptionsProvider cacheOptionsProvider) : BaseService(memoryCache), ISaleService
{
    private readonly ISaleRepository _saleRepository = saleRepository;
    private readonly IDealershRepository _dealershRepository = dealershRepository;
    private readonly IClientRepository _clientRepository = clientRepository;
    private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
    private readonly CacheOptionsProvider _cacheOptionsProvider = cacheOptionsProvider;

    public async Task<bool> AddAsync(SaleCreateRequest request)
    {
        if (!(await _clientRepository.VerifyExist(request.IdClient)))
            return false;

        if (!(await _dealershRepository.VerifyExist(request.IdDealersh)))
            return false;

        if (!(await _vehicleRepository.VerifyExist(request.IdVehicle)))
            return false;

        ClearCache();
        await _saleRepository.AddAsync(request.ToEntity());
       
        return true;

    }

    public async Task DeleteAsync(int id) 
    {
        ClearCache();
        await _saleRepository.DeleteAsync(id);
    } 

    public async Task<IEnumerable<SaleResponse>> GetAllAsync()
    {
        if (!_memoryCache.TryGetValue("sales", out IEnumerable<Sale> sales))
        {
            sales = await _saleRepository.GetAllAsync();
            _memoryCache.Set("sales", sales, _cacheOptionsProvider.GetCacheOptions());
            AddCacheKey("sales");
        }

        return sales.ToResponse();
    }

    public async Task<SaleResponse> GetByIdAsync(int id)
    {
        if (!_memoryCache.TryGetValue($"saleId:{id}", out Sale sale))
        {
            sale = await _saleRepository.GetByIdAsync(id);
            _memoryCache.Set($"saleId:{id}", sale, _cacheOptionsProvider.GetCacheOptions());
            AddCacheKey($"saleId:{id}");
        }
        return sale.ToResponse();
    }

    public async Task<bool> UpdateAsync(int id, SaleUpdateRequest request)
    {
        Sale? sale = await _saleRepository.GetByIdAsync(id);

        if (sale is null)
            return false;

        if (request.DataSale is not null) sale.DataSale = (DateTime)request.DataSale;

        if (request.SalePrice is not null) sale.SalePrice = (decimal)request.SalePrice;

        sale.UpdatedAt = DateTime.Now;

        ClearCache();
        await _saleRepository.UpdateAsync(sale);
       
        return true;
    }
}
