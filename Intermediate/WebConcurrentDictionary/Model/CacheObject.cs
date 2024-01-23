using System;

namespace WebConcurrentDictionary.Model
{
    public class CacheObject
    {
        public Object Data { set; get; }
        public string HashCode { set; get; }

        public CacheObject(Object data, string hashCode = null)
        {
            this.Data = data;
            this.HashCode = hashCode;
        }
    }
}
