using Microsoft.EntityFrameworkCore;
using AuthenticationService.DataLayer.Models.User;
using Microsoft.Extensions.Configuration;

namespace AuthenticationService.DataLayer.Context
{
    public class UserDbContext : DbContext
    {

        public UserDbContext()
        {

        }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<UserModel> User_Db { get; set; }

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
