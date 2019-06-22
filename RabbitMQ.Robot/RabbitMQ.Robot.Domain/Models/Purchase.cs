using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Robot.Domain
{
    public class Purchase
    {
        [JsonProperty("userId")]
        public Guid UserId { get; set; }

        [JsonProperty("productId")]
        public Guid ProductId { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }

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
