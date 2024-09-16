using AutoInventoryPro.Infraestructure.Context;
using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoInventoryPro.Infraestructure.Repositories;

public class SaleRepository(AutoInventoryProDbContext context) : BaseRepository<Sale>(context), ISaleRepository
{
    private readonly AutoInventoryProDbContext _context = context;

    public async override Task<Sale> GetByIdDetailAsync(int id)
    {
        return await _context.Sales.Include(s => s.Client).
                                    Include(s => s.Vehicle).
                                    Include(s => s.Dealersh).
                                    SingleOrDefaultAsync(f => f.Id == id);
    }
}
