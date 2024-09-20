using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Services.Mappers;
using AutoInventoryPro.Views.Dealersh.Requests;
using AutoInventoryPro.Views.Dealersh.Responses;

namespace AutoInventoryPro.Services.Services;

public class DealershService(IDealershRepository dealershRepository) : IDealershService
{
    private readonly IDealershRepository _dealershRepository = dealershRepository;

    public async  Task AddAsync(DealershCreateRequest request)
    {
        var dealersh = request.ToEntity();
        await _dealershRepository.AddAsync(dealersh);
    }

    public Task DeleteAsync(int id) => _dealershRepository.DeleteAsync(id);

    public async Task<IEnumerable<DealershResponse>> GetAllAsync()
    {
        var dealershes = await _dealershRepository.GetAllAsync();
        return dealershes.ToResponse();
    }

    public async Task<DealershResponse> GetByIdAsync(int id)
    {
        var dealersh = await _dealershRepository.GetByIdAsync(id);
        return dealersh.ToResponse();
    }

    public async Task<bool> UpdateAsync(int id, DealershUpdateRequest request)
    {
        var dealersh = await _dealershRepository.GetByIdAsync(id);

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

        await _dealershRepository.UpdateAsync(dealersh);
        return true;
    }
}
