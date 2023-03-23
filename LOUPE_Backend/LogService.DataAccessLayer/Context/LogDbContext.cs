using LogService.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace LogService.DataAccessLayer.Context;

public class LogDbContext : DbContext
{
    public LogDbContext()
    {

    }

    public LogDbContext(DbContextOptions<LogDbContext> options) : base(options)
    {
    }

    public DbSet<Log> Logs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "";
        connectionString = "Server=localhost,1433;User=SA;Password=Welkom12345";
        optionsBuilder.UseSqlServer(connectionString);
    }
}