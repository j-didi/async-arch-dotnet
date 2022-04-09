using AsyncArch.Core.Ports;
using Microsoft.Extensions.Caching.Distributed;

namespace AsyncArch.Infra.Cache;

public class CacheAdapter: ICachePort
{
    private readonly IDistributedCache _cache;

    public CacheAdapter(IDistributedCache cache)
    {
        _cache = cache;
    }
    
    public async Task<string> Read(Guid id) =>
        await _cache.GetStringAsync(id.ToString());

    public async Task Write(Guid id, string json) =>
        await _cache.SetStringAsync(
            id.ToString(),
            json, 
            GetEntryOptions()
        );

    public async Task Remove(Guid id) =>
        await _cache.RemoveAsync(id.ToString());
    
    private static DistributedCacheEntryOptions GetEntryOptions() =>
        new() { AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(7) };
}