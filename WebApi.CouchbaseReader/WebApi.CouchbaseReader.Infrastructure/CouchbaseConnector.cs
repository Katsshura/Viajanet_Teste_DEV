using Couchbase;
using Couchbase.Authentication;
using Couchbase.Configuration.Client;
using Couchbase.Core;
using System;
using System.Collections.Generic;

namespace WebApi.CouchbaseReader.Infrastructure
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

            if (bucket != null)
            {
                CreateIndexesOnCouchbase();
            }
        }

        public static IBucket GetBucketInstance()
        {
            return bucket;
        }

        public static void CloseCouchbaseConnection()
        {
            ClusterHelper.Close();
        }

        private static async void CreateIndexesOnCouchbase()
        {
            var bucketManager = bucket.CreateManager();
            await bucketManager.CreateN1qlPrimaryIndexAsync(true);
            await bucketManager.CreateN1qlIndexAsync("ix_type", true, new string[] { "type" });
            await bucketManager.CreateN1qlIndexAsync("ix_emai", true, new string[] { "email" });
            await bucketManager.CreateN1qlIndexAsync("ix_pass", true, new string[] { "pass" });
            await bucketManager.CreateN1qlIndexAsync("ix_title", true, new string[] { "title" });
            await bucketManager.CreateN1qlIndexAsync("ix_ip", true, new string[] { "ip" });
            await bucketManager.CreateN1qlIndexAsync("ix_pageName", true, new string[] { "pageName" });
            await bucketManager.BuildN1qlDeferredIndexesAsync();
            bucketManager.WatchN1qlIndexes(
                new List<string> {
                "ix_type",
                "ix_email",
                "ix_pass",
                "ix_title",
                "ix_ip",
                "ix_pageName",
                "#primary"
            }, TimeSpan.FromSeconds(2));
        }
    }
}
