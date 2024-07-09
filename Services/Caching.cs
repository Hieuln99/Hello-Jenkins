using StackExchange.Redis;

namespace Worker.Services
{
    public class Caching : ICaching
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _database;
        public Caching(IConnectionMultiplexer connectionMultiplexer)
        {
            this._connectionMultiplexer = connectionMultiplexer;
            this._database = this._connectionMultiplexer.GetDatabase();
        }

        public string GetCacheResponse(string cacheKey)
        {
            return this._database.StringGet(cacheKey).ToString();
        }

        public bool SetCacheResponse(string cacheKey, string response, TimeSpan? timeOut = null)
        {
            if (timeOut == null)
            {
                timeOut = TimeSpan.FromDays(2);
            }

            if (response == null)
            {
                return false;
            }

            this._database.StringSet(cacheKey, response, timeOut);

            return !string.IsNullOrEmpty(this.GetCacheResponse(cacheKey));
        }
    }
}
