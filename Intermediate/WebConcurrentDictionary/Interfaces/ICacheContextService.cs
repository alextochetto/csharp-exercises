using System;
using System.Threading.Tasks;

namespace WebConcurrentDictionary.Interfaces
{
    public interface ICacheContextService
    {
        Task<T> GetOrAdd<T>(string key, Func<Task<T>> funcValue);
    }
}
