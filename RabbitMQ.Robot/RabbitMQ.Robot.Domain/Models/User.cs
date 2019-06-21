using Newtonsoft.Json;

namespace RabbitMQ.Robot.Domain
{
    public class User
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phoneNumber")]
        public long PhoneNumber { get; set; }

        [JsonProperty("streetAddress")]
        public string StreetAddress { get; set; }

        [JsonProperty("houseNumber")]
        public string HouseNumber { get; set; }

        [JsonProperty("neighborhood")]
        public string Neighborhood { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        public static BrowserInformation FromJson(string json)
        {
            return JsonConvert.DeserializeObject<BrowserInformation>(json, JsonConverter.Settings);
        }

        public static string ToJson(User self)
        {
            return JsonConvert.SerializeObject(self, JsonConverter.Settings);
        }

        public override string ToString()
        {
            string temp = Name + " " + LastName;
            return temp;
        }
    }
}
