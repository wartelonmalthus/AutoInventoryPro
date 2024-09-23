using Microsoft.Extensions.Caching.Memory;

namespace AutoInventoryPro.Services.Services;

public abstract class BaseService
{
    protected readonly IMemoryCache _memoryCache;

    protected static List<string> _cacheKeys = new List<string>();

    public BaseService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    protected void ClearCache()
    {
        foreach (var cacheKey in _cacheKeys)
        {
            _memoryCache.Remove(cacheKey);
        }
    }

    protected void AddCacheKey(string key)
    {
        if (!_cacheKeys.Contains(key))
        {
            _cacheKeys.Add(key);
        }
    }
}
