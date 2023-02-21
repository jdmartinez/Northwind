using Microsoft.EntityFrameworkCore;

using Northwind.Shared.Application.Interfaces;

namespace Northwind.Shared.Application;

public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly DbContext _context;

    public RepositoryBase(DbContext context) => _context = context;

    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken token = default)
    {
        await _context.Set<TEntity>().AddAsync(entity, token);

        return entity;
    }    

    public void DeleteAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<IReadOnlyList<TEntity>?> GetAllAsync(CancellationToken token = default)
    {
        var result = await _context.Set<TEntity>().ToListAsync(token);

        return result?.AsReadOnly();
    }

    public virtual async Task<TEntity?> GetAsync<TId>(TId id, CancellationToken token = default) where TId : notnull
        => await _context.Set<TEntity>().FindAsync(new object[] { id }, token);

    public virtual void Update(TEntity entity)  => _context.Set<TEntity>().Update(entity);

    public virtual void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);

    public virtual async Task<int> SaveChangesAsync(CancellationToken token = default)
        => await _context.SaveChangesAsync(token);
}
