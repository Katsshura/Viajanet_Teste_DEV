namespace RabbitMQ.Robot.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
