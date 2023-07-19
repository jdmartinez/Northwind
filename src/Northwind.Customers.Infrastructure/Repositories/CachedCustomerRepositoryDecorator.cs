using Northwind.Customers.Application.Repositories;
using Northwind.Shared.Domain.Entities;
using Northwind.Shared.Infrastructure.Caching.Interfaces;

namespace Northwind.Customers.Infrastructure.Repositories;

public class CachedCustomerRepositoryDecorator : ICustomerRepository
{
    private readonly ICustomerRepository _repository;
    private readonly ICacheProvider _cache;

    public CachedCustomerRepositoryDecorator(ICustomerRepository repository, ICacheProvider cache)
    {
        _repository = repository;
        _cache = cache;
    }

    public Task<Customer> AddAsync(Customer entity, CancellationToken token = default) => _repository.AddAsync(entity, token);

    public void Delete(Customer entity) => _repository.Delete(entity);

    public async Task<IReadOnlyList<Customer>?> GetAllAsync(CancellationToken token = default)
    {
        var cacheKey = $"{typeof(Customer).Name}-all";

        return await _cache.GetOrCreateValueAsync(cacheKey, async () => await _repository.GetAllAsync(token), null, token);
    }

    public async Task<Customer?> GetAsync<TId>(TId id, CancellationToken token = default) where TId : notnull
    {
        var cacheKey = $"{typeof(Customer).Name}-{id}";

        return await _cache.GetOrCreateValueAsync(cacheKey, async () => await _repository.GetAsync(id, token), null, token);
    }

    public Task<int> SaveChangesAsync(CancellationToken token = default) => _repository.SaveChangesAsync(token);

    public void Update(Customer entity) => _repository.Update(entity);
    
}
