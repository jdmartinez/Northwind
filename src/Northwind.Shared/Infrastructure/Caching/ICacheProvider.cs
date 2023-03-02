namespace Northwind.Shared.Infrastructure.Caching;

public interface ICacheProvider 
{
    Task SetValueAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken token = default);

    Task<T?> GetValueAsync<T>(string key, CancellationToken token = default);

    Task<T?> GetOrCreateValueAsync<T>(string key, Func<T> factory, TimeSpan? expiration = null, CancellationToken token = default);

    Task<T?> GetOrCreateValueAsync<T>(string key, Func<Task<T>> factory, TimeSpan? expiration = null, CancellationToken token = default);
}
