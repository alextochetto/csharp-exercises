using System.Collections.Concurrent;
using WebConcurrentDictionary.Interfaces;
using WebConcurrentDictionary.Model;

namespace WebConcurrentDictionary.Services
{
    public class CacheService : ICacheService
    {
        private readonly ConcurrentDictionary<string, CacheObject> _cache = new ConcurrentDictionary<string, CacheObject>();
        public T Get<T>(string key)
        {
            if (!_cache.TryGetValue(key, out CacheObject value))
                return default(T);
            return (T)value.Data;
        }

        public void Set(string key, object value)
        {
            CacheObject cacheEntry = new CacheObject(value);
            if (this._cache.ContainsKey(key))
                this._cache[key] = cacheEntry;
            else
                this._cache.TryAdd(key, cacheEntry);
        }

        public void Remove(string key)
        {
            this._cache.TryRemove(key, out _);
        }
    }
}