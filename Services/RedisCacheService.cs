using ScrutorApiExperiment.Interfaces;
using StackExchange.Redis;

namespace ScrutorApiExperiment.Services;

public class RedisCacheService : ICacheService
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
    }

    public async Task<string> GetCacheValueAsync(string key)
    {
        var redisDatabase = GetRedisDatabase();
        return await redisDatabase.StringGetAsync(key);
    }

    public async Task SetCacheValueAsync(
        string key,
        string value,
        TimeSpan expirationTime
    )
    {
        var redisDatabase = GetRedisDatabase();
        await redisDatabase.StringSetAsync(key, value, expirationTime);
    }

    private IDatabase GetRedisDatabase()
    {
        var redisDatabase = _connectionMultiplexer.GetDatabase();

        if (redisDatabase is null)
        {
            throw new RedisConnectionException(ConnectionFailureType.UnableToConnect, "Error trying to connect to REDIS");
        }

        return redisDatabase;
    }
}
