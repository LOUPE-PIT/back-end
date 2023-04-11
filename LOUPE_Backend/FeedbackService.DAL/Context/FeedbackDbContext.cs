using FeedbackService.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FeedbackService.DAL.Context
{
    public class FeedbackDbContext : DbContext
    {

        public DbSet<FeedbackDbo> FeedbackDbo { get; set; }

        public FeedbackDbContext()
        {
               
        }

        public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options) : base(options)
        {

        }

 

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
