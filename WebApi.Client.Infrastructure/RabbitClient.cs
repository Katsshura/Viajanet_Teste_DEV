using RabbitMQ.Client;
using System.Text;

namespace WebApi.Client.Infrastructure
{
    public class RabbitClient
    {
        public void SendMessageToQueue(string message)
        {
            IModel channel = RabbitMQConnection.GetRabbitMQChannel("localhost", "client_browser_info");
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "", routingKey: "browser", basicProperties: null, body: body);
        }
    }
}
