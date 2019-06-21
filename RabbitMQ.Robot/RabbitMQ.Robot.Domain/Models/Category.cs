using Newtonsoft.Json;

namespace RabbitMQ.Robot.Domain
{
    public class Category
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        public static Category FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Category>(json, JsonConverter.Settings);
        }

        public static string ToJson(Category self)
        {
            return JsonConvert.SerializeObject(self, JsonConverter.Settings);
        }

        public override string ToString()
        {
            return Title;
        }
    }
}