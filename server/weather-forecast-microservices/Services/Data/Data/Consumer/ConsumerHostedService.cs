using Data.Service;

namespace Data.Consumer
{
    public class ConsumerHostedService : BackgroundService
    {
        private readonly IWeatherConsumerService _weatherDataService;

        public ConsumerHostedService(IWeatherConsumerService weatherDataService)
        {
            _weatherDataService = weatherDataService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _weatherDataService.GetCurrentWeatherData("", "");
            await _weatherDataService.GetDailyWeatherData("", "");
        }
    }
}
