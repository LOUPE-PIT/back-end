using LogHandler.Microservice.Model;
using Microsoft.EntityFrameworkCore;

namespace LogHandler.Microservice.Context
{
    public class LogDbContext : DbContext
    {
        public LogDbContext()
        {

        }

        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options)
        {
        }

        public DbSet<LogModel> Log { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var confuguration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = confuguration.GetConnectionString("AppDb");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
