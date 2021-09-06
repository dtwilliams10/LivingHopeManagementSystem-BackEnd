using LHMSAPI.Models;
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
            options.UseNpgsql(Configuration.GetConnectionString("LHMS"));
        }

        public DbSet<SystemReport> SystemReports { get; set; }
        public DbSet<SystemReportStatus> SystemReportStatus { get; set; }
        public DbSet<SystemName> SystemName { get; set; }

    }

}