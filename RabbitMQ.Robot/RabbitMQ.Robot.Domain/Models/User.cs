namespace RabbitMQ.Robot.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string StreetAddress { get; set; }
        public string HouseNumber { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public override string ToString()
        {
            string temp = Name + " " + LastName;
            return temp;
        }
    }
}
