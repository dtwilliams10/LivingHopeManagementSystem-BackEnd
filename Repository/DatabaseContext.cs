using Microsoft.EntityFrameworkCore;

namespace LHMSAPI.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){ }
        public DbSet<SystemReport> SystemReports { get; set; }
        
    }

}