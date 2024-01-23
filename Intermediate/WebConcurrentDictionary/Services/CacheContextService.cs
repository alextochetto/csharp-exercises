using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using WebConcurrentDictionary.Interfaces;
using WebConcurrentDictionary.Model;

namespace WebConcurrentDictionary.Services
{
    public class CacheContextService : ICacheContextService
    {
        private readonly ConcurrentDictionary<string, CacheObject> _cacheContext = new ConcurrentDictionary<string, CacheObject>();
        private readonly ICacheService _cacheService;

        public CacheContextService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<T> GetOrAdd<T>(string key, Func<Task<T>> funcValue)
        {
            if (this._cacheContext.TryGetValue(key, out CacheObject cacheObject))
                return (T)cacheObject.Data;
            T value = this._cacheService.Get<T>(key);
            if (value is null)
            {
                value = await funcValue();
                if (value != null)
                    this._cacheService.Set(key, value);
            }
            CacheObject cacheObjectNew = new CacheObject(value);
            //this._cache.AddOrUpdate(key, cacheObjectNew, (key, cacheObjectNew) => cacheObjectNew);
            this._cacheContext.AddOrUpdate(key, cacheObjectNew, Update);
            return value;
        }

        private CacheObject Update(string key, CacheObject cacheEntry)
        {
            return (cacheEntry);
        }
    }
}
