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
            string connectionString = "";

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

                connectionString = configuration.GetConnectionString("AppDb");

            }
            else
            {
                connectionString = Environment.GetEnvironmentVariable("ConnectionStrings:AppDb");
            }


            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
