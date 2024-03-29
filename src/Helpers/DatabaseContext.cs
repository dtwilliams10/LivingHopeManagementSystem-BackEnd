﻿using LHMS.SystemReports.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LHMS.SystemReports.Helpers
{
    public class DatabaseContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DatabaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseNpgsql(Configuration.GetConnectionString("SystemReports"), o => o.UseNodaTime()).UseSnakeCaseNamingConvention();
        public DbSet<SystemReport> SystemReports { get; set; }
        public DbSet<SystemReportStatus> SystemReportStatus { get; set; }
        public DbSet<SystemName> SystemNames { get; set; }
    }
}