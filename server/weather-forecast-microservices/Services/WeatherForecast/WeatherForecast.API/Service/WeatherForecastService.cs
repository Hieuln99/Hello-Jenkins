using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Services;
using System.Text;
using WeatherForecast.API.Model;
using WeatherForecast.API.Utility;

namespace WeatherForecast.API.Service
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly IRabbitMQService _rabbitMqService;

        public WeatherForecastService(IRabbitMQService rabbitMqService)
        {
            this._httpClient = new HttpClient();
            this._httpClient.BaseAddress = new Uri("http://localhost:5005/");
            _rabbitMqService = rabbitMqService;
        }

        const string currentWeatherQuece = "current-weather-queue";
        const string weatherForecastQueue = "weather-forecast-queue";

        public async Task<CurrentWeather> GetCurrentWeather(string lat, string lon)
        {
            try
            {
                var tcs = new TaskCompletionSource<CurrentWeather>();

                // Rabbit MQ
                using var connection = _rabbitMqService.CreateChannel();

                using var model = connection.CreateModel();

                var replyQueue = model.QueueDeclare("", exclusive: true);
                model.QueueDeclare(currentWeatherQuece, exclusive: false);

                var consumer = new AsyncEventingBasicConsumer(model);

                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($"Reply Recieved: {message}");

                    var result = StringExtensions.DeserializeObject<CurrentWeather>(message);
                    await Task.CompletedTask;
                    tcs.SetResult(result);
                };

                model.BasicConsume(queue: replyQueue.QueueName, autoAck: true, consumer: consumer);

                var properties = model.CreateBasicProperties();
                properties.ReplyTo = replyQueue.QueueName;
                properties.CorrelationId = Guid.NewGuid().ToString();

                var message = $"{lat};{lon}";
                var body = Encoding.UTF8.GetBytes(message);

                Console.WriteLine($"Sending Request: {properties.CorrelationId} - message: {message}");

                model.BasicPublish("", currentWeatherQuece, properties, body);
                // Rabbit MQ

                return await tcs.Task;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DailyWeather> GetWeatherForecast(string lat, string lon)
        {
            try
            {
                var tcs = new TaskCompletionSource<DailyWeather>();

                // Rabbit MQ
                using var connection = _rabbitMqService.CreateChannel();

                using var model = connection.CreateModel();

                var replyQueue = model.QueueDeclare("", exclusive: true);
                model.QueueDeclare(weatherForecastQueue, exclusive: false);

                var consumer = new AsyncEventingBasicConsumer(model);

                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($"Reply Recieved: {message}");

                    var result = StringExtensions.DeserializeObject<DailyWeather>(message);
                    await Task.CompletedTask;
                    tcs.SetResult(result);
                };

                model.BasicConsume(queue: replyQueue.QueueName, autoAck: true, consumer: consumer);

                var properties = model.CreateBasicProperties();
                properties.ReplyTo = replyQueue.QueueName;
                properties.CorrelationId = Guid.NewGuid().ToString();

                var message = $"{lat};{lon}";
                var body = Encoding.UTF8.GetBytes(message);

                Console.WriteLine($"Sending Request: {properties.CorrelationId} - message: {message}");

                model.BasicPublish("", weatherForecastQueue, properties, body);
                // Rabbit MQ

                return await tcs.Task;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
