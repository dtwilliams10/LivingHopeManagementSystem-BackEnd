using LHMSAPI.Models;
using LHMSAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LHMSAPI.Helpers
{
    public class DatabaseContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("PostgreSQL"));
        }
        public DbSet<SystemReport> SystemReports { get; set; }
        public DbSet<SystemStatus> SystemStatus { get; set; }
        public DbSet<SystemName> SystemName { get; set; }

        public DbSet<User> Users {get; set;}
   }

}