using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LHMS.SystemReports.Entities;
using LHMS.SystemReports.Helpers;
using Serilog;

namespace Models
{
    public class Seed
    {
        public static async Task SeedData(DatabaseContext context)
        {
            Log.Information("Attempting to Seed Database");
            var systemReports = new List<SystemReport>();
            var systemReportStatuses = new List<SystemReportStatus>();
            var systemNames = new List<SystemName>();

            if (!context.SystemNames.Any())
            {
                Log.Information("Building Seed Data");
                systemNames = new List<SystemName>
                {
                    new SystemName
                    {
                        Name = "Administrative"
                    },
                    new SystemName
                    {
                        Name = "Campus Preservation"
                    },
                    new SystemName
                    {
                        Name = "Childrens"
                    },
                    new SystemName
                    {
                        Name = "Christian Development"
                    },
                    new SystemName
                    {
                        Name = "Creative"
                    },
                    new SystemName
                    {
                        Name = "First Touch"
                    },
                    new SystemName
                    {
                        Name = "Hispanic"
                    },
                    new SystemName
                    {
                        Name = "Media"
                    },
                    new SystemName
                    {
                        Name = "Second Touch"
                    },
                    new SystemName
                    {
                        Name = "Specialized Ministries"
                    },
                    new SystemName
                    {
                        Name = "Worship"
                    },
                    new SystemName
                    {
                        Name = "Youth"
                    }
                };
            }
            if (!context.SystemReportStatus.Any())
            {
                systemReportStatuses = new List<SystemReportStatus>
                {
                    new SystemReportStatus
                    {
                        Status = "Inactive"
                    },
                    new SystemReportStatus
                    {
                        Status = "Draft"
                    },
                    new SystemReportStatus
                    {
                        Status = "Submitted to Team Lead"
                    },
                    new SystemReportStatus
                    {
                        Status = "Rejected by Team Lead"
                    },
                    new SystemReportStatus
                    {
                        Status = "Approved By Team Lead"
                    },
                    new SystemReportStatus
                    {
                        Status = "Submitted to System Director"
                    },
                    new SystemReportStatus
                    {
                        Status = "Rejected by System Director"
                    },
                    new SystemReportStatus
                    {
                        Status = "Approved by System Director"
                    },
                    new SystemReportStatus
                    {
                        Status = "Submitted to Administrative Pastor"
                    },
                    new SystemReportStatus
                    {
                        Status = "Rejected by Administrative Pastor"
                    },
                    new SystemReportStatus
                    {
                        Status = "Approved by Administrative Pastor"
                    },
                    new SystemReportStatus
                    {
                        Status = "Submitted to Senior Pastor"
                    },
                    new SystemReportStatus
                    {
                        Status = "Rejected by Senior Pastor"
                    },
                    new SystemReportStatus
                    {
                        Status = "Approved by Senior Pastor"
                    }
                };
            }
            if (!context.SystemReports.Any())
            {
                systemReports = new List<SystemReport>
                {
                    new SystemReport
                    {
                        ReporterId = 1,
                        ReportName = "Creative System Report",
                        ReportDate = NodaTime.Instant.FromUtc(2023, 03, 15, 00, 00),
                        CreatedDate = NodaTime.Instant.FromUtc(2023, 03, 15, 00, 00),
                        SystemReportStatusId = 5,
                        SystemNameId = 5,
                        SystemUpdate = "This is my system update",
                        PersonnelUpdates = "These are my personnel updates",
                        CreativeIdeasAndEvaluations = "These are my createive ideas and evaluations",
                        BarriersOrChallenges = "These are my barriers or challenges",
                        HowCanIHelpYou = "This is how you can help me",
                        PersonalGrowthAndDevelopment = "This is my personal growth and development"
                    },
                    new SystemReport
                    {
                        ReporterId = 1,
                        ReportName = "First Touch System Report",
                        ReportDate = NodaTime.Instant.FromUtc(2023, 03, 15, 00, 00),
                        CreatedDate = NodaTime.Instant.FromUtc(2023, 03, 15, 00, 00),
                        SystemReportStatusId = 4,
                        SystemNameId = 6,
                        SystemUpdate = "This is my system update",
                        PersonnelUpdates = "These are my personnel updates",
                        CreativeIdeasAndEvaluations = "These are my createive ideas and evaluations",
                        BarriersOrChallenges = "These are my barriers or challenges",
                        HowCanIHelpYou = "This is how you can help me",
                        PersonalGrowthAndDevelopment = "This is my personal growth and development"
                    }
                };
            }

            await context.SystemNames.AddRangeAsync(systemNames);
            await context.SystemReportStatus.AddRangeAsync(systemReportStatuses);
            await context.SystemReports.AddRangeAsync(systemReports);
            await context.SaveChangesAsync();

            Log.Information("Database Seeded Successfully");
        }
    }
};