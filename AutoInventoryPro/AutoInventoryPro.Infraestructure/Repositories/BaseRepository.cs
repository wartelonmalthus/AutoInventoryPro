using AutoInventoryPro.Infraestructure.Context;
using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoInventoryPro.Infraestructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
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
   public async Task<bool> VerifyExist(int id)
    {
        return await _dbSet.AnyAsync(x => x.Id == id);
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

    public virtual async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.Where(x => x.SoftDelete == false).ToListAsync();
    public virtual async Task<T> GetByIdDetailAsync(int id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
    public async Task<T> GetByIdAsync(int id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
}
