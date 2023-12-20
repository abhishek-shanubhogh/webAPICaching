using System.Runtime.Caching;
namespace webAPICaching.Services

{
    public class CacheService : ICache
    {
        private ObjectCache _cacheValue = MemoryCache.Default;

        

        public T getData<T>(string key)
        {
            try
            {
                T item = (T)_cacheValue.Get(key);
                return item;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public object Remove(string key)
        {
            var res = true;

            if (!string.IsNullOrEmpty(key))
            {
                _cacheValue.Remove(key);

            }
            else
                res = false;
            return res;
        }

        public bool setData<T>(string key, T value, DateTimeOffset expire)
        {
            var res = true;
            try
            {
                if (!string.IsNullOrEmpty(key))
                {
                    _cacheValue.Set(key, value, expire);

                }
                else 
                    res=false;
                return res;


            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
