using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Services.Mappers;
using AutoInventoryPro.Views.Sale.Requests;
using AutoInventoryPro.Views.Sale.Responses;

namespace AutoInventoryPro.Services.Services;

public class SaleService(ISaleRepository saleRepository, IDealershRepository dealershRepository, IClientRepository clientRepository, IVehicleRepository vehicleRepository) : ISaleService
{
    private readonly ISaleRepository _saleRepository = saleRepository;
    private readonly IDealershRepository _dealershRepository = dealershRepository;
    private readonly IClientRepository _clientRepository = clientRepository;
    private readonly IVehicleRepository _vehicleRepository = vehicleRepository;

    public async Task<bool> AddAsync(SaleCreateRequest request)
    {
        if (!(await _clientRepository.VerifyExist(request.IdClient)))
            return false;

        if (!(await _dealershRepository.VerifyExist(request.IdDealersh)))
            return false;

        if (!(await _vehicleRepository.VerifyExist(request.IdVehicle)))
            return false;


        var sale = request.ToEntity();

        await _saleRepository.AddAsync(sale);
        return true;

    }

    public Task DeleteAsync(int id) => _saleRepository.DeleteAsync(id);

    public async Task<IEnumerable<SaleResponse>> GetAllAsync()
    {
        var sales = await _saleRepository.GetAllAsync();
        return sales.ToResponse();
    }

    public async Task<SaleResponse> GetByIdAsync(int id)
    {
        var sale = await _saleRepository.GetByIdAsync(id);
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
