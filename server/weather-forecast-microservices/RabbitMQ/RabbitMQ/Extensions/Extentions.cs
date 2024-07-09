using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Models;
using RabbitMQ.Services;

namespace RabbitMQ.Extensions
{
    public static class Extentions
    {
        public static void AddMessageBroker(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMQConfiguration>(a => configuration.GetSection(nameof(RabbitMQConfiguration)).Bind(a));
            services.AddSingleton<IRabbitMQService, RabbitMQService>();
        }
    }
}
