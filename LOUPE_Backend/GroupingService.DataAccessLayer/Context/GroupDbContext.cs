using System.Diagnostics;
using GroupingService.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GroupingService.DataAccessLayer.Context;

public class GroupDbContext : DbContext
{
    public GroupDbContext()
    {
        
    }
    public GroupDbContext(DbContextOptions<GroupDbContext> options) : base(options)
    {
    }
    public DbSet<Group> Groups { get; set; }
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