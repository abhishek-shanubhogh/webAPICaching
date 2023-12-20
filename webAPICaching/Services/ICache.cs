namespace webAPICaching.Services
{
    public interface ICache
    {
        T getData<T>(string key);
        bool setData<T>(string key, T value,DateTimeOffset expire);

        object Remove(string key);
    }
}
