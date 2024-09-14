using AutoInventoryPro.Infraestructure.Context;
using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Models.Interfaces.Repositorires;
using Microsoft.EntityFrameworkCore;

namespace AutoInventoryPro.Infraestructure.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly AutoInventoryProDbContext _context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(AutoInventoryProDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();

    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            entity.SoftDelete = true;
            await UpdateAsync(entity);
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
}
