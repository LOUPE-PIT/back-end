using LogService.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LogService.DataAccessLayer.Context;

public class LogDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public LogDbContext()
    {
        
    }

    public LogDbContext(DbContextOptions<LogDbContext> options) : base(options)
    {
    }

    public DbSet<Log> Logs { get; set; }
}