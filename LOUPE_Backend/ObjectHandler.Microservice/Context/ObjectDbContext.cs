using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ObjectHandler.Microservice.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("AppDb");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}