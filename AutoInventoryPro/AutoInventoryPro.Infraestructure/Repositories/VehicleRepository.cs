using AutoInventoryPro.Infraestructure.Context;
using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoInventoryPro.Infraestructure.Repositories;

public class VehicleRepository(AutoInventoryProDbContext context) : BaseRepository<Vehicle>(context), IVehicleRepository
{
    private readonly AutoInventoryProDbContext _context = context;

    public async override Task<Vehicle> GetByIdDetailAsync(int id)
    {
        return await _context.Vehicles.Include(v => v.Fabricator).SingleOrDefaultAsync(f => f.Id == id);
    }
}
