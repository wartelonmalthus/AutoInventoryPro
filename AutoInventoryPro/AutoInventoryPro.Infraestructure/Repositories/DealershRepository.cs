using AutoInventoryPro.Infraestructure.Context;
using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoInventoryPro.Infraestructure.Repositories;

public class DealershRepository(AutoInventoryProDbContext context) : BaseRepository<Dealersh>(context), IDealershRepository
{
    private readonly AutoInventoryProDbContext _context = context;
    public async override Task<Dealersh> GetByIdDetailAsync(int id)
    {
        return await _context.Dealershes.Include(d => d.Sales).SingleOrDefaultAsync(d => d.Id == id);
    }
}
