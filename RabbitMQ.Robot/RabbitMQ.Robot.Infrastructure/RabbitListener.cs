using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQ.Robot.Infrastructure
{
    public class RabbitListener
    {
        public void ReceiveMessageOnQueue(string route)
        {
            Console.WriteLine("\nRunning Robot Setup...");
            IModel channel = RabbitMQConnection.GetRabbitMQChannel("localhost", route);
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);

            if (route == RabbitRoutesUtillity.Browser_Route)
            {
                consumer.Received += OnReceivedMessageBrowser;
            }
            else
            {
                consumer.Received += OnReceivedMessagePurchase;
            }

            channel.BasicConsume(queue: route, autoAck: true, consumer: consumer);
            Console.WriteLine("\nListening on: " + route);
            
        }

        private void OnReceivedMessageBrowser(object consumer, BasicDeliverEventArgs eventArgs)
        {
            string message = DecodeEventArgBody(eventArgs.Body);
            Console.WriteLine(" [x] Received on Browser{0}", message);
        }

        private void OnReceivedMessagePurchase(object consumer, BasicDeliverEventArgs eventArgs)
        {
            string message = DecodeEventArgBody(eventArgs.Body);
            Console.WriteLine(" [x] Received on Purchase {0}", message);
        }

        private string DecodeEventArgBody(byte[] body)
        {
            return Encoding.UTF8.GetString(body);
        }
    }
}
