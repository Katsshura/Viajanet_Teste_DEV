using RabbitMQ.Client;
using System.Text;

namespace WebApi.Client.Infrastructure
{
    public class RabbitClient
    {
        public void SendMessageToQueue(string message, string route)
        {
            IModel channel = RabbitMQConnection.GetRabbitMQChannel("localhost", route);
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "", routingKey: route, basicProperties: null, body: body);
        }
    }
}
