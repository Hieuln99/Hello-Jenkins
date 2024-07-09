namespace Data.Service
{
    public interface IWeatherConsumerService
    {
        public Task GetCurrentWeatherData(string lat, string lon);
        public Task GetDailyWeatherData(string lat, string lon);
    }
}
