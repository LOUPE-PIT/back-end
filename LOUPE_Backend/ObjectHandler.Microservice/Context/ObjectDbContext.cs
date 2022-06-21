using Microsoft.EntityFrameworkCore;
using ObjectHandler.Microservice.Model;

namespace ObjectHandler.Microservice.Context
{
    public class ObjectDbContext : DbContext
    {
        public ObjectDbContext()
        {

        }

        public ObjectDbContext(DbContextOptions<ObjectDbContext> options) : base(options)
        {
        }

        public DbSet<ObjectModel> Object { get; set; }

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