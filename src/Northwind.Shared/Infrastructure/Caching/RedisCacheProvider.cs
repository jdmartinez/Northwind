using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

using Northwind.Shared.Infrastructure.Caching.Interfaces;

using StackExchange.Redis;

namespace Northwind.Shared.Infrastructure.Caching;

public class RedisCacheProvider : ICacheProvider
{
    private readonly IConnectionMultiplexer _connection;
    private readonly IDatabase _db;

    public RedisCacheProvider(IConnectionMultiplexer connection)
    {
        _connection = connection;
        _db = _connection.GetDatabase();
    }

    public async Task<T?> GetValueAsync<T>(string key, CancellationToken token = default)
    {
        token.ThrowIfCancellationRequested();

        var cachedValue = await _db.StringGetAsync(key);

        return !cachedValue.IsNullOrEmpty ? JsonSerializer.Deserialize<T>(cachedValue!) : default;
    }

    public async Task SetValueAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken token = default)
    {
        token.ThrowIfCancellationRequested();        

        if (value == null) return;

        var cachedValue = JsonSerializer.Serialize(value);

        await _db.StringSetAsync(key, cachedValue, expiration);
    }

    public async Task<T?> GetOrCreateValueAsync<T>(string key, Func<Task<T>> factory, TimeSpan? expiration, CancellationToken token = default)
    {
        var cachedValue = await GetValueAsync<T>(key, token);

        if (cachedValue != null) return cachedValue;

        if (factory == null) return default;

        cachedValue = await factory();

        await SetValueAsync(key, cachedValue, expiration, token);

        return cachedValue;
    }
}
