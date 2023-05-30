using LogService.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LogService.DataAccessLayer.Context;

public class LogDbContext : DbContext
{
    public DbSet<Log> Logs { get; set; }
    public LogDbContext()
    {
        
    }

    public LogDbContext(DbContextOptions<LogDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        var connectionString = configuration.GetConnectionString("logDb");

        optionsBuilder.UseSqlServer(connectionString);
    }
}