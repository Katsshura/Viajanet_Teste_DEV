using Newtonsoft.Json;

namespace RabbitMQ.Robot.Domain
{
    public class Product
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("categoryId")]
        public long CategoryId { get; set; }

        public virtual Category Category { get; set; }

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
