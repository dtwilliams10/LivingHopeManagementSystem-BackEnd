using Microsoft.EntityFrameworkCore;

public class SystemReportContext : DbContext
    {
        public SystemReportContext (DbContextOptions<SystemReportContext> options)
            : base(options)
        {
        }

        public DbSet<LHMSAPI.Models.SystemReport> SystemReport { get; set; }
    }
