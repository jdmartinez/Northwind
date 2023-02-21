namespace Northwind.Shared.Application.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity?> GetAsync<TId>(TId id, CancellationToken token = default) where TId : notnull;

    Task<IReadOnlyList<TEntity>?> GetAllAsync(CancellationToken token = default);

    Task<TEntity> AddAsync(TEntity entity, CancellationToken token = default);

    void Update(TEntity entity);

    void Delete(TEntity entity);

    Task<int> SaveChangesAsync(CancellationToken token = default);
}
