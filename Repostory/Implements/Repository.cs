using BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.Implements;

public abstract class Repository<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
    where TEntityId : class
{
    protected readonly AppDbContext _context;

    protected Repository(AppDbContext context)
    {
        _context = context;
    }

    public virtual Task<TEntity?> GetByIdAsync(TEntityId id)
    {
        return _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var result = await _context.Set<TEntity>().ToArrayAsync();
        return result.AsEnumerable();
    }

    public virtual TEntity Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        return entity;
    }
    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }
    public void Remove(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }
}
