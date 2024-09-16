using AutoInventoryPro.Infraestructure.Repositories;
using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Views.Client.Requests;
using AutoInventoryPro.Views.Client.Responses;

namespace AutoInventoryPro.Services.Services;

public class ClientService(ClientRepository clientRepository) : IClientService
{
    private readonly ClientRepository _clientRepository = clientRepository;

    public Task AddAsync(ClientCreateRequest request)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ClientResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ClientResponse> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(ClientUpdateRequest entity)
    {
        throw new NotImplementedException();
    }
}
