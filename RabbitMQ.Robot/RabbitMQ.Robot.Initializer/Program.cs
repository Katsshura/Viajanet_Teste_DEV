using RabbitMQ.Robot.Infrastructure;
using System;

namespace RabbitMQ.Robot.Initializer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing Robot...");
            RabbitListener listener = new RabbitListener();
            listener.ReceiveMessageOnQueue("client_browser_info");
            listener.ReceiveMessageOnQueue("client_purchase_info");
        }
    }
}
