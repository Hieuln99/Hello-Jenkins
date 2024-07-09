namespace Worker.Services
{
    public interface ICaching
    {
        string GetCacheResponse(string cacheKey);
        bool SetCacheResponse(string cacheKey, string response, TimeSpan? timeOut = null);
    }
}
