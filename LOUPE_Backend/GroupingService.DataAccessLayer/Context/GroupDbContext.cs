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
        string connectionString = "";
        connectionString = "Server=localhost,1433;User=SA;Password=Welkom12345";
        optionsBuilder.UseSqlServer(connectionString);
    }
}