using System.Text.Json;

using StackExchange.Redis;

namespace Northwind.Shared.Infrastructure.Caching.Redis;

public class RedisCacheProvider : ICacheProvider
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;
    private readonly IDatabase _db;

    public RedisCacheProvider(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
        _db = connectionMultiplexer.GetDatabase();
    }

    public async Task<T?> GetValueAsync<T>(string key, CancellationToken token = default)
    {        
        token.ThrowIfCancellationRequested();

        var cachedValue = await _db.StringGetAsync(key);

        return !cachedValue.IsNullOrEmpty ? JsonSerializer.Deserialize<T>(cachedValue!) : default;
    }

    public async Task<T?> GetOrCreateValueAsync<T>(string key, Func<T> factory, TimeSpan? expiration = null, CancellationToken token = default)
    {
        var cachedValue = await GetValueAsync<T>(key, token);

        if (cachedValue != null) return cachedValue;

        if (factory is null) return default;

        cachedValue = factory();

        await SetValueAsync(key, cachedValue, expiration, token);

        return cachedValue;
    }

    public async Task<T?> GetOrCreateValueAsync<T>(string key, Func<Task<T>> factory, TimeSpan? expiration = null, CancellationToken token = default)
    {
        var cachedValue = await GetValueAsync<T>(key, token);

        if (cachedValue != null) return cachedValue;

        if (factory is null) return default;

        cachedValue = await factory();

        await SetValueAsync(key, cachedValue, expiration, token);

        return cachedValue;
    }

    public async Task SetValueAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken token = default)
    {
        if (value == null) return;

        token.ThrowIfCancellationRequested();

        var cachedValue = JsonSerializer.Serialize(value);

        await _db.StringSetAsync(key, cachedValue, expiration);
    }
}
