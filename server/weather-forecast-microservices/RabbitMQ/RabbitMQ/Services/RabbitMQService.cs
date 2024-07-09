using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Models;

namespace RabbitMQ.Services
{
    public class RabbitMQService: IRabbitMQService
    {
        private readonly RabbitMQConfiguration _configuration;
        public RabbitMQService(IOptions<RabbitMQConfiguration> options)
        {
            _configuration = options.Value;
        }

        public IConnection CreateChannel()
        {
            ConnectionFactory connection = new ConnectionFactory()
            {
                UserName = _configuration.Username,
                Password = _configuration.Password,
                HostName = _configuration.HostName,
            };

            connection.DispatchConsumersAsync = true;
            var channel = connection.CreateConnection();
            return channel;
        }
    }
}
