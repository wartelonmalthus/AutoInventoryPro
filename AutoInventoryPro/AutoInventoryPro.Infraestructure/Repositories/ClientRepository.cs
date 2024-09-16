using AutoInventoryPro.Infraestructure.Context;
using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Models.Interfaces.Repositorires;

namespace AutoInventoryPro.Infraestructure.Repositories;

public class ClientRepository(AutoInventoryProDbContext context) : BaseRepository<Client>(context), IClientRepository
{
    
}
