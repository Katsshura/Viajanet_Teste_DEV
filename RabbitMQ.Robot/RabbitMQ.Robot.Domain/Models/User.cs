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

        [JsonProperty("password")]
        public string Password { get; set; }

        public static User FromJson(string json)
        {
            return JsonConvert.DeserializeObject<User>(json, JsonConverter.Settings);
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
