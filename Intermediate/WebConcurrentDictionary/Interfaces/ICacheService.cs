namespace WebConcurrentDictionary.Interfaces
{
    public interface ICacheService
    {
        T Get<T>(string key);
        void Set(string key, object value);
    }
}