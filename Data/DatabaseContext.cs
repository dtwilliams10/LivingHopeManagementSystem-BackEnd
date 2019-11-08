using LHMSAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LHMSAPI.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() {}
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){ }
        public DbSet<SystemReport> SystemReports { get; set; }
        public DbSet<SystemStatus> SystemStatus { get; set; }
        public DbSet<SystemName> SystemName { get; set; }
   }

}