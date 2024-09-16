using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Services.Mappers;
using AutoInventoryPro.Views.Client.Requests;
using AutoInventoryPro.Views.Client.Responses;

namespace AutoInventoryPro.Services.Services;

public class ClientService(IClientRepository clientRepository) : IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task AddAsync(ClientCreateRequest request)
    {
        var client = request.ToEntity();
        await _clientRepository.AddAsync(client);
    }

    public Task DeleteAsync(int id) => _clientRepository.DeleteAsync(id);

    public async Task<IEnumerable<ClientResponse>> GetAllAsync()
    {
        var clients = await _clientRepository.GetAllAsync();
        return clients.ToResponse();
    }

    public async Task<ClientResponse> GetByIdAsync(int id)
    {
        var client = await _clientRepository.GetByIdDetailAsync(id);
        return client.ToResponse();
    }

    public async Task<bool> UpdateAsync(int id, ClientUpdateRequest request)
    {
        var client = await _clientRepository.GetByIdAsync(id);

        if (client is null)
            return false;

        if (request.CPF is not null) client.CPF = request.CPF;

        if (request.Name is not null) client.Name = request.Name;

        if (request.Phone is not null) client.Phone = request.Phone;

        client.UpdatedAt = DateTime.Now;

        await _clientRepository.UpdateAsync(client);
        return true;
    }
}
