using GroupingService.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GroupingService.DataAccessLayer.Context;

public class GroupDbContext : DbContext
{
    //Tables
    public DbSet<Group> Groups { get; set; } = null!;
    public DbSet<ArchivedGroup> ArchivedGroups { get; set; } = null!;
    
    public GroupDbContext()
    {
        
    }
    public GroupDbContext(DbContextOptions<GroupDbContext> options) : base(options)
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