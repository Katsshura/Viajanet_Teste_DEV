﻿using Newtonsoft.Json;
using System;

namespace RabbitMQ.Robot.Domain
{
    public class Product
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        public static Product FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Product>(json, JsonSettings.Settings);
        }

        public static string ToJson(Product self)
        {
            return JsonConvert.SerializeObject(self, JsonSettings.Settings);
        }

        public override string ToString()
        {
            return Title;
        }

        public override bool Equals(object obj)
        {
            var item = obj as Product;
            
            if(item == null)
            {
                return false;
            }

            return this.Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
