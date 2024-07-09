using Data.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using WeatherForecast.API.Service;

namespace WeatherForecast.API.Controllers
{
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly IWeatherConsumerService _weatherConsumerService;
        public WeatherForecastController(IWeatherForecastService weatherForecastService, IWeatherConsumerService weatherConsumerService)
        {
            this._weatherForecastService = weatherForecastService;
            this._weatherConsumerService = weatherConsumerService;
        }

        [HttpGet("current-weather")]
        public async Task<IActionResult> GetCurrentWeather(string lat, string lon)
        {
            try
            {
                var currentWeather = await _weatherForecastService.GetCurrentWeather(lat, lon);
                return Ok(currentWeather);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("weather-forecast")]
        public async Task<IActionResult> GetWeatherForecast(string lat, string lon)
        {
            try
            {
                var weatherForecast = await _weatherForecastService.GetWeatherForecast(lat, lon);
                return Ok(weatherForecast);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        private static string GenarateCacheKeyFromRequest(HttpRequest request)
        {
            var keyBuilder = new StringBuilder();
            keyBuilder.Append($"{request.Path}");

            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
            {
                keyBuilder.Append($"|{key}-{value}");
            }

            return keyBuilder.ToString();
        }
    }
}
