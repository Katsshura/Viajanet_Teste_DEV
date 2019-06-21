using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Robot.Domain;
using RabbitMQ.Robot.Infrastructure.DataContent;
using System;
using System.Text;

namespace RabbitMQ.Robot.Infrastructure
{
    public class RabbitListener
    {
        private readonly SqlServerData db;

        public RabbitListener(SqlServerData db)
        {
            this.db = db;
        }

        #region Receiver

        //Receive message and assigns the correct method

        public void ReceiveMessageOnQueue(string route)
        {
            Console.WriteLine("\nRunning Robot Setup...");
            IModel channel = RabbitMQConnection.GetRabbitMQChannel("localhost", route);
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);

            if (route == RabbitRoutesUtillity.Browser_Route)
            {
                consumer.Received += OnReceivedMessageBrowser;
            }
            else if(route == RabbitRoutesUtillity.Purchase_Route)
            {
                consumer.Received += OnReceivedMessagePurchase;
            }
            else if(route == RabbitRoutesUtillity.User_Route)
            {
                consumer.Received += OnReceivedMessageUser;
            }

            channel.BasicConsume(queue: route, autoAck: true, consumer: consumer);
            Console.WriteLine("\nListening on: " + route);
        }
        #endregion

        #region Handlers OnReceivedMessage

        /// <summary> Handle the messages from RabbitMQ
        ///<para>Messages are separated according to their queue. Then json is converted into the respective queue object</para>
        /// </summary>
        /// 
        private void OnReceivedMessageBrowser(object consumer, BasicDeliverEventArgs eventArgs)
        {
            string message = DecodeEventArgBody(eventArgs.Body);
            BrowserInformation browserObj = BrowserInformation.FromJson(message);

        }

        private void OnReceivedMessagePurchase(object consumer, BasicDeliverEventArgs eventArgs)
        {
            string message = DecodeEventArgBody(eventArgs.Body);
            Purchase purchaseObj = Purchase.FromJson(message);
        }

        private void OnReceivedMessageUser(object consumer, BasicDeliverEventArgs eventArgs)
        {
            string message = DecodeEventArgBody(eventArgs.Body);
            User userObj = User.FromJson(message);
        }

        #endregion

        private string DecodeEventArgBody(byte[] body)
        {
            return Encoding.UTF8.GetString(body);
        }

        private void AddObjectIntoDatabase(object obj)
        {
            try
            {
                db.Add(obj);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
