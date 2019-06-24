using Couchbase.Core;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Robot.Domain;
using RabbitMQ.Robot.Infrastructure.Connections;
using RabbitMQ.Robot.Infrastructure.DataContent;
using System;
using System.Linq;
using System.Text;

namespace RabbitMQ.Robot.Infrastructure
{
    public class RabbitListener
    {
        private readonly SqlServerData db;
        private readonly IBucket _bucket = CouchbaseConnector.GetBucketInstance();

        public RabbitListener(SqlServerData db)
        {
            this.db = db;
            db.Database.Migrate();
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
            else if (route == RabbitRoutesUtillity.Purchase_Route)
            {
                consumer.Received += OnReceivedMessagePurchase;
            }
            else if (route == RabbitRoutesUtillity.User_Route)
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

            string key = GenerateRandomGuidString();

            db.BrowserInformations.ContainsAsync(browserObj).ContinueWith((result) =>
            {
                if (!result.Result)
                {
                    AddObjectIntoSqlDatabase(browserObj);
                    //Add BrowserInformation into Couchbase bucket
                    _bucket.Upsert(key, new
                    {
                        Ip = browserObj.Ip,
                        PageName = browserObj.PageName,
                        BrowserName = browserObj.BrowserName,
                        Type = browserObj.GetType().Name
                    });
                }
                else
                {
                    Console.WriteLine("Already exists in database");
                }
            });
        }

        private void OnReceivedMessagePurchase(object consumer, BasicDeliverEventArgs eventArgs)
        {
            string message = DecodeEventArgBody(eventArgs.Body);
            Purchase purchaseObj = Purchase.FromJson(message);
            Guid key = Guid.NewGuid();

            purchaseObj.Id = key;

            AddObjectIntoSqlDatabase(purchaseObj);

            //Add Purchase into Couchbase bucket
            _bucket.Upsert(key.ToString(), new
            {
                ProductId = purchaseObj.ProductId,
                UserId = purchaseObj.UserId,
                Type = purchaseObj.GetType().Name
            });
        }

        private void OnReceivedMessageUser(object consumer, BasicDeliverEventArgs eventArgs)
        {
            string message = DecodeEventArgBody(eventArgs.Body);
            User userObj = User.FromJson(message);

            if (!userObj.Id.HasValue) { userObj.Id = Guid.NewGuid(); }

            AddObjectIntoSqlDatabase(userObj);
            //Add User into Couchbase bucket
            _bucket.Upsert(userObj.Id.ToString(), new
            {
                Name = userObj.Name,
                LastName = userObj.LastName,
                Email = userObj.Email,
                Pass = userObj.Password,
                PhoneNumber = userObj.PhoneNumber,
                Type = userObj.GetType().Name
            });
        }

        #endregion

        private string DecodeEventArgBody(byte[] body) => Encoding.UTF8.GetString(body);

        private string GenerateRandomGuidString() => Guid.NewGuid().ToString();

        private void AddObjectIntoSqlDatabase(object obj)
        {
            try
            {
                object a = db.Add(obj);
                db.SaveChanges();
                Console.WriteLine("Added to SQL Server");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //WARNING: Only use this method for development purposes
        //To use this method, call it on RabbitListener Constructor
        //If your database is already populated this can create duplicated
        //files on Couchbase!
        private void PopulateDatabasesWithInitialProducts()
        {

            Product one = new Product();
            Product two = new Product();
            Product three = new Product();
            Product four = new Product();

            one.Id = Guid.NewGuid(); one.Title = "Basic Package";
            one.Desc = "Product 1 description"; one.Price = 10.99m;
            db.Add(one);
            _bucket.Upsert(one.Id.ToString(), new
            {
                Title = one.Title,
                Desc = one.Desc,
                Price = one.Price,
                Type = one.GetType().Name
            });

            two.Id = Guid.NewGuid(); two.Title = "Deluxe Package";
            two.Desc = "Product 2 description"; two.Price = 15.99m;
            db.Add(two);
            _bucket.Upsert(two.Id.ToString(), new
            {
                Title = two.Title,
                Desc = two.Desc,
                Price = two.Price,
                Type = two.GetType().Name
            });

            three.Id = Guid.NewGuid(); three.Title = "Premium Package";
            three.Desc = "Product 3 description"; three.Price = 20.99m;
            db.Add(three);
            _bucket.Upsert(three.Id.ToString(), new
            {
                Title = three.Title,
                Desc = three.Desc,
                Price = three.Price,
                Type = three.GetType().Name
            });

            db.SaveChanges();
            Console.WriteLine("Products were populated into databases");
        }
    }
}
