using Northwind.Customers.Application.Repositories;
using Northwind.Shared.Domain.Entities;
using Northwind.Shared.Infrastructure.Caching;

namespace Northwind.Customers.Infrastructure.Repositories;

public class CachedCustomerRepository : ICustomerRepository
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICacheProvider _cache;

    public CachedCustomerRepository(ICustomerRepository customerRepository, ICacheProvider cache)
    {
        _customerRepository = customerRepository;
        _cache = cache;
    }

    public Task<Customer> AddAsync(Customer entity, CancellationToken token = default)
        => _customerRepository.AddAsync(entity, token);

    public void Delete(Customer entity) => _customerRepository.Delete(entity);
    

    public async Task<IReadOnlyList<Customer>?> GetAllAsync(CancellationToken token = default)
    {
        var cacheKey = GetCacheKey("all");

        return await _cache.GetOrCreateValueAsync(cacheKey,
            async () =>
            {
                await Task.Delay(100, token);
                return await _customerRepository.GetAllAsync(token);
            }, null, token);
    }

    public async Task<Customer?> GetAsync<TId>(TId id, CancellationToken token = default) where TId : notnull
    {
        var cacheKey = GetCacheKey(id.ToString());

        return await _cache.GetOrCreateValueAsync(cacheKey,
            async () =>
            {
                await Task.Delay(100, token);
                return await _customerRepository.GetAsync(id, token);
            }, null, token);
    }

    public Task<int> SaveChangesAsync(CancellationToken token = default) => _customerRepository.SaveChangesAsync(token);

    public void Update(Customer entity) => _customerRepository.Update(entity);
    

    private string GetCacheKey(string args) => $"{nameof(Customer)}-{args}";
}
