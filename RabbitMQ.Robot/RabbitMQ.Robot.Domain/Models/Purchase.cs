using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Robot.Domain.Models
{
    public class Purchase
    {
        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("productId")]
        public long ProductId { get; set; }

        public static Purchase FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Purchase>(json, JsonConverter.Settings);
        }

        public static string ToJson(Purchase self)
        {
            return JsonConvert.SerializeObject(self, JsonConverter.Settings);
        }

    }
}
