using AutoInventoryPro.Infraestructure.Context;
using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoInventoryPro.Infraestructure.Repositories;

public class FabricatorRepository(AutoInventoryProDbContext context) : BaseRepository<Fabricator>(context), IFabricatorRepository
{
    private readonly AutoInventoryProDbContext _context = context;

    public async override Task<Fabricator> GetByIdDetailAsync(int id)
    {
        return await _context.Fabricators.Include(f => f.Vehicles).SingleOrDefaultAsync(f => f.Id == id);
    }
}
