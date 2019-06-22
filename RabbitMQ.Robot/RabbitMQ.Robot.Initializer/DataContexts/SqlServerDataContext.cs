using Microsoft.EntityFrameworkCore;
using RabbitMQ.Robot.Domain;
using RabbitMQ.Robot.Infrastructure.DataContent;
using RabbitMQ.Robot.Initializer.Util;

namespace RabbitMQ.Robot.Initializer.DataContexts
{
    class SqlServerDataContext : SqlServerData
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => SqlServerUtillity.OnConfiguring(optionsBuilder);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrowserInformation>()
                .ToTable("BrowserInformation")
                .HasKey(key => new { key.PageName, key.Ip });

            modelBuilder.Entity<Product>()
                .ToTable("Product");

            modelBuilder.Entity<User>()
                .ToTable("User");

            modelBuilder.Entity<Purchase>()
                .ToTable("Purhcase")
                .HasKey(key => new { key.UserId, key.ProductId});
        }
    }
}
