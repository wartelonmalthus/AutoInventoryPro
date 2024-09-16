using AutoInventoryPro.Infraestructure.Context;
using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoInventoryPro.Infraestructure.Repositories;

public class ClientRepository(AutoInventoryProDbContext context) : BaseRepository<Client>(context), IClientRepository
{
    private readonly AutoInventoryProDbContext _context = context;
    public async override Task<Client> GetByIdDetailAsync(int id)
    {
        return await _context.Clients.Include(c => c.Sales).SingleOrDefaultAsync(c => c.Id == id);
    }
}
