namespace RabbitMQ.Robot.Domain
{
    public class BrowserInformation
    {
        public string Ip { get; set; }
        public string PageName { get; set; }
        public string BrowserName { get; set; }

        public override string ToString()
        {
            string temp = Ip + " On Page: " + PageName;
            return temp;
        }
    }
}
