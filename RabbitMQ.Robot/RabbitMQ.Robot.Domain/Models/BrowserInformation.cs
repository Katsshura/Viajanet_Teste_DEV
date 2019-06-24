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
            return JsonConvert.DeserializeObject<BrowserInformation>(json, JsonSettings.Settings);
        }

        public static string ToJson(BrowserInformation self)
        {
            return JsonConvert.SerializeObject(self, JsonSettings.Settings);
        }

        public override string ToString()
        {
            string temp = Ip + " On Page: " + PageName;
            return temp;
        }

        public override bool Equals(object obj)
        {
            var item = obj as BrowserInformation;

            if(item == null)
            {
                return false;
            }

            return this.Ip.Equals(item.Ip) && this.PageName.Equals(item.PageName);
        }

        public override int GetHashCode()
        {
            return this.Ip.GetHashCode() + this.PageName.GetHashCode();
        }
    }
}
