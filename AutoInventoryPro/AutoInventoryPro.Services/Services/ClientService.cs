using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Services.Cache;
using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Services.Mappers;
using AutoInventoryPro.Views.Client.Requests;
using AutoInventoryPro.Views.Client.Responses;
using Microsoft.Extensions.Caching.Memory;

namespace AutoInventoryPro.Services.Services;

public class ClientService(IClientRepository clientRepository, IMemoryCache memoryCache, CacheOptionsProvider cacheOptionsProvider) : BaseService(memoryCache),  IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;
    private readonly CacheOptionsProvider _cacheOptionsProvider = cacheOptionsProvider;

    public async Task AddAsync(ClientCreateRequest request)
    {
        ClearCache();
        await _clientRepository.AddAsync(request.ToEntity());
       
    }
    public async Task DeleteAsync(int id) 
    {
        ClearCache();
        await _clientRepository.DeleteAsync(id);
       
    } 

    public async Task<IEnumerable<ClientResponse>> GetAllAsync()
    {
        if (!_memoryCache.TryGetValue("clients", out IEnumerable<Client> clients))
        {
            clients = await _clientRepository.GetAllAsync();
            _memoryCache.Set("clients", clients, _cacheOptionsProvider.GetCacheOptions());
            AddCacheKey("clients");
        }

        return clients.ToResponse();

    }

    public async Task<ClientResponse> GetByIdAsync(int id)
    {
        if (!_memoryCache.TryGetValue($"clientId:{id}", out Client client))
        {
            client = await _clientRepository.GetByIdAsync(id);
            _memoryCache.Set($"clientId:{id}", client, _cacheOptionsProvider.GetCacheOptions());
            AddCacheKey($"clientId:{id}");
        }
        return client.ToResponse();
    }

    public async Task<bool> UpdateAsync(int id, ClientUpdateRequest request)
    {
        Client? client = await _clientRepository.GetByIdAsync(id);

        if (client is null)
            return false;

        if (request.CPF is not null) client.CPF = request.CPF;

        if (request.Name is not null) client.Name = request.Name;

        if (request.Phone is not null) client.Phone = request.Phone;

        client.UpdatedAt = DateTime.Now;

        ClearCache();
        await _clientRepository.UpdateAsync(client);
        
        return true;
    }
}
