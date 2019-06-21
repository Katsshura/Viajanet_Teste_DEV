using Microsoft.EntityFrameworkCore;
using RabbitMQ.Robot.Domain;

namespace RabbitMQ.Robot.Infrastructure.DataContent
{
    public class SqlServerData : DbContext
    {
        public DbSet<BrowserInformation> BrowserInformations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
