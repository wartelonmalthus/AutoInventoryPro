using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Services.Mappers;
using AutoInventoryPro.Views.Sale.Requests;
using AutoInventoryPro.Views.Sale.Responses;

namespace AutoInventoryPro.Services.Services;

public class SaleService(ISaleRepository saleRepository) : ISaleService
{
    private readonly ISaleRepository _saleRepository = saleRepository;

    public async Task AddAsync(SaleCreateRequest request)
    {
        var sale = request.ToEntity();
        await _saleRepository.AddAsync(sale);
    }

    public Task DeleteAsync(int id) => _saleRepository.DeleteAsync(id);

    public async Task<IEnumerable<SaleResponse>> GetAllAsync()
    {
        var sales = await _saleRepository.GetAllAsync();
        return sales.ToResponse();
    }

    public async Task<SaleResponse> GetByIdAsync(int id)
    {
        var sale = await _saleRepository.GetByIdDetailAsync(id);
        return sale.ToResponse();
    }

    public async Task<bool> UpdateAsync(int id, SaleUpdateRequest request)
    {
        var sale = await _saleRepository.GetByIdAsync(id);

        if (sale is null)
            return false;

        if (request.DataSale is not null) sale.DataSale = (DateTime)request.DataSale;

        if (request.SalePrice is not null) sale.SalePrice = (decimal)request.SalePrice;

        sale.UpdatedAt = DateTime.Now;

        await _saleRepository.UpdateAsync(sale);
        return true;
    }
}
