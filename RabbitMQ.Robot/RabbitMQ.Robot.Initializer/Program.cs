using RabbitMQ.Robot.Domain;
using RabbitMQ.Robot.Infrastructure;
using RabbitMQ.Robot.Initializer.DataContexts;
using System;

namespace RabbitMQ.Robot.Initializer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing Robot...");

            SqlServerDataContext dataContext = new SqlServerDataContext();

            RabbitListener listener = new RabbitListener(dataContext);

            listener.ReceiveMessageOnQueue("client_browser_info");
            listener.ReceiveMessageOnQueue("client_purchase_info");
            listener.ReceiveMessageOnQueue("client_user_info");
        }
    }
}
