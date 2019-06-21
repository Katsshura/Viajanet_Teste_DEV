using Newtonsoft.Json;

namespace RabbitMQ.Robot.Domain
{
    public class BrowserInformation
    {
        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("pageName")]
        public string PageName { get; set; }

        [JsonProperty("browserName")]
        public string BrowserName { get; set; }

        public static BrowserInformation FromJson(string json)
        {
            return JsonConvert.DeserializeObject<BrowserInformation>(json, JsonConverter.Settings);
        }

        public static string ToJson(BrowserInformation self)
        {
            return JsonConvert.SerializeObject(self, JsonConverter.Settings);
        }

        public override string ToString()
        {
            string temp = Ip + " On Page: " + PageName;
            return temp;
        }
    }
}
