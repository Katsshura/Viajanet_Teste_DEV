using Newtonsoft.Json;
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
            return JsonConvert.DeserializeObject<Product>(json, JsonConverter.Settings);
        }

        public static string ToJson(Product self)
        {
            return JsonConvert.SerializeObject(self, JsonConverter.Settings);
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
