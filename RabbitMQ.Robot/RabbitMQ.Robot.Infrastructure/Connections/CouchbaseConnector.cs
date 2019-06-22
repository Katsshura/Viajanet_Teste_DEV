using Couchbase;
using Couchbase.Authentication;
using Couchbase.Configuration.Client;
using Couchbase.Core;
using System;
using System.Collections.Generic;

namespace RabbitMQ.Robot.Infrastructure.Connections
{
    public class CouchbaseConnector
    {
        private static readonly string User = "myuser";
        private static readonly string Password = "123456";
        private static readonly string BucketName = "ViajanetDB";

        private static IBucket bucket;

        public static void OpenCouchbaseConnection()
        {
            ClusterHelper.Initialize(new ClientConfiguration
            {
                Servers = new List<Uri> {
                    new Uri("couchbase://localhost")
                }

            }, new PasswordAuthenticator(User, Password));

            bucket = ClusterHelper.GetBucket(BucketName);
        }

        public static IBucket GetBucketInstance()
        {
            return bucket;
        }

        public static void CloseCouchbaseConnection()
        {
            ClusterHelper.Close();
        }
    }
}
