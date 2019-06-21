using RabbitMQ.Client;

namespace WebApi.Client.Infrastructure
{
    public sealed class RabbitMQConnection
    {
        public static IModel GetRabbitMQChannel(string host, string queue) {
            var factory = new ConnectionFactory() { HostName = host };
            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();
            channel.QueueDeclare(queue: queue,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

            return channel;
        }
    }
}
