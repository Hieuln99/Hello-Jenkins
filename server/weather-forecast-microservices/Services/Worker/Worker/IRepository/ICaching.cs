namespace Worker.Repository
{
    public interface ICaching
    {
        string GetCacheResponse(string cacheKey);
        bool SetCacheResponse(string cacheKey, object response, TimeSpan? timeOut = null);
        bool RemoveCache(string cacheKey);
    }
}
