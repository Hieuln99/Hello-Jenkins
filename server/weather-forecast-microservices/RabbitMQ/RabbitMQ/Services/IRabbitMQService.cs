using RabbitMQ.Client;

namespace RabbitMQ.Services
{
    public interface IRabbitMQService
    {
        IConnection CreateChannel();
    }
}
