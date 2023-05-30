using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserService.DataLayer.Models.User;

namespace UserService.DataLayer.Context
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
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("AppDb");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
