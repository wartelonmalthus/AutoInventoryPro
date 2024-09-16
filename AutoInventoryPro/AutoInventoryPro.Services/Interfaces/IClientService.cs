using AutoInventoryPro.Views.Client.Requests;
using AutoInventoryPro.Views.Client.Responses;

namespace AutoInventoryPro.Services.Interfaces;

public interface IClientService
{ 
    Task<IEnumerable<ClientResponse>> GetAllAsync();
    Task<ClientResponse> GetByIdAsync(int id);
    Task AddAsync(ClientCreateRequest request);
    Task<bool> UpdateAsync(int id, ClientUpdateRequest request);
    Task DeleteAsync(int id);

}
