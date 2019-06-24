using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Robot.Domain
{
    public class Purchase
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("userId")]
        public Guid UserId { get; set; }

        [JsonProperty("productId")]
        public Guid ProductId { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }

        public static Purchase FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Purchase>(json, JsonSettings.Settings);
        }

        public static string ToJson(Purchase self)
        {
            return JsonConvert.SerializeObject(self, JsonSettings.Settings);
        }

        public override bool Equals(object obj)
        {
            var item = obj as Purchase;

            if (item == null)
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
