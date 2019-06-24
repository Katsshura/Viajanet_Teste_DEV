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
                .ToTable("User")
                .HasIndex(p => p.Email)
                .IsUnique(true);

            modelBuilder.Entity<Purchase>()
                .ToTable("Purchase")
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Purchase>()
                .HasKey(key => new { key.Id});
        }
    }
}
