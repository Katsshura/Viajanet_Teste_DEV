using Microsoft.EntityFrameworkCore;

namespace RabbitMQ.Robot.Initializer.Util
{
    public class SqlServerUtillity
    {
        public static readonly string UrlSqlServer = @"Server=(localdb)\mssqllocaldb;Database=Viajanet.Evaluation;Trusted_Connection=True;";

        public static void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseSqlServer(UrlSqlServer);
        }
    }
}
