using Microsoft.EntityFrameworkCore;
using Worker.Services;

namespace Worker
{
    public class Workers(ILogger<Workers> logger, IHttpClientFactory httpClientFactory, ICaching caching, IServiceProvider serviceProvider) : BackgroundService
    {
        private readonly ILogger<Workers> _logger = logger;
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly string apiKey = "a138902a1200a09b2c57e0119815c601";
        private readonly ICaching _caching = caching;
        private readonly List<WeatherData> weatherDatas = [];
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    if (_logger.IsEnabled(LogLevel.Information))
                    {
                        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    }

                    weatherDatas.Clear();
                    foreach (var item in Model.Provinces)
                    {
                        // Gọi API khi khởi động
                        await CallApiAsync(
                            item.Id,
                            item.Name ?? string.Empty,
                            item.Lat ?? string.Empty,
                            item.Lon ?? string.Empty,
                            "7",
                        stoppingToken);
                    }

                    using (var scope = this._serviceProvider.CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetService<WorkerDbContext>();
                        dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE \"WeatherDatas\"");
                        await dbContext.WeatherDatas.AddRangeAsync(weatherDatas, stoppingToken);
                        await dbContext.SaveChangesAsync(stoppingToken);
                    }

                    _logger.LogInformation("Data added to the database.");

                    await Task.Delay(20000, stoppingToken);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error calling API: {e.Message}");
            }
        }

        private async Task CallApiAsync(int index, string province, string latitude, string longitude, string count, CancellationToken stoppingToken)
        {
            using var client = _httpClientFactory.CreateClient();
            try
            {
                client.BaseAddress = new Uri("https://api.openweathermap.org/");

                var version = "data/2.5/";
                string url = $"{version}forecast?lat={latitude}&lon={longitude}&cnt={count}&appid={apiKey}&units=metric";
                HttpResponseMessage response = await client.GetAsync(url.ToString(), stoppingToken);
                response.EnsureSuccessStatusCode();
                var dailyData = await response.Content.ReadAsStringAsync(stoppingToken);

                var result = this._caching.SetCacheResponse($"DailyWeatherData-province:{province}-lat:{latitude}-lon:{longitude}", dailyData);
                if (!result)
                {
                    Exception exception = new("Set Cache Response Failed");
                    throw exception;
                }
                _logger.LogInformation($"Save DailyWeatherData--province:{province}-lat:{latitude}-lon:{longitude} success");
                
                url = $"{version}weather?lat={latitude}&lon={longitude}&appid={apiKey}&units=metric";
                response = await client.GetAsync(url.ToString(), stoppingToken);
                response.EnsureSuccessStatusCode();
                var currentData = await response.Content.ReadAsStringAsync(stoppingToken);

                result = this._caching.SetCacheResponse($"CurrentWeatherData-province:{province}-lat:{latitude}-lon:{longitude}", currentData);
                if (!result)
                {
                    Exception exception = new("Set Cache Response Failed");
                    throw exception;
                }
                _logger.LogInformation($"Save CurrentWeatherData--province:{province}-lat:{latitude}-lon:{longitude} success");

                this.weatherDatas.Add(new WeatherData { Id = index, DataDaily = dailyData });
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error calling API: {e.Message}");
            }
        }
    }
}
