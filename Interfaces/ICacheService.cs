﻿namespace ScrutorApiExperiment.Interfaces;

public interface ICacheService
{
    Task<string> GetCacheValueAsync(string key);

    Task SetCacheValueAsync(
        string key,
        string value,
        TimeSpan expirationTime
    );
}
