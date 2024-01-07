using System;
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
                    new() {
                        Name = "Administrative"
                    },
                    new() {
                        Name = "Campus Preservation"
                    },
                    new() {
                        Name = "Childrens"
                    },
                    new() {
                        Name = "Christian Development"
                    },
                    new() {
                        Name = "Creative"
                    },
                    new() {
                        Name = "First Touch"
                    },
                    new() {
                        Name = "Hispanic"
                    },
                    new() {
                        Name = "Media"
                    },
                    new() {
                        Name = "Second Touch"
                    },
                    new() {
                        Name = "Specialized Ministries"
                    },
                    new() {
                        Name = "Worship"
                    },
                    new() {
                        Name = "Youth"
                    }
                };
            }
            if (!context.SystemReportStatus.Any())
            {
                systemReportStatuses = new List<SystemReportStatus>
                {
                    new() {
                        Status = "Inactive"
                    },
                    new() {
                        Status = "Draft"
                    },
                    new() {
                        Status = "Submitted to Team Lead"
                    },
                    new() {
                        Status = "Rejected by Team Lead"
                    },
                    new() {
                        Status = "Approved By Team Lead"
                    },
                    new() {
                        Status = "Submitted to System Director"
                    },
                    new() {
                        Status = "Rejected by System Director"
                    },
                    new() {
                        Status = "Approved by System Director"
                    },
                    new() {
                        Status = "Submitted to Administrative Pastor"
                    },
                    new() {
                        Status = "Rejected by Administrative Pastor"
                    },
                    new() {
                        Status = "Approved by Administrative Pastor"
                    },
                    new() {
                        Status = "Submitted to Senior Pastor"
                    },
                    new() {
                        Status = "Rejected by Senior Pastor"
                    },
                    new() {
                        Status = "Approved by Senior Pastor"
                    }
                };
            }
            if (!context.SystemReports.Any())
            {
                systemReports = new List<SystemReport>
                {
                    new() {
                        ReporterId = "1",
                        ReportName = "Creative System Report",
                        ReportDate = NodaTime.Instant.FromDateTimeUtc(DateTime.UtcNow),
                        CreatedDate = NodaTime.Instant.FromDateTimeUtc(DateTime.UtcNow),
                        SystemReportStatusId = 5,
                        SystemNameId = 5,
                        SystemUpdate = "This is my system update",
                        PersonnelUpdates = "These are my personnel updates",
                        CreativeIdeasAndEvaluations = "These are my createive ideas and evaluations",
                        BarriersOrChallenges = "These are my barriers or challenges",
                        HowCanIHelpYou = "This is how you can help me",
                        PersonalGrowthAndDevelopment = "This is my personal growth and development"
                    },
                    new() {
                        ReporterId = "1",
                        ReportName = "First Touch System Report",
                        ReportDate = NodaTime.Instant.FromDateTimeUtc(DateTime.UtcNow),
                        CreatedDate = NodaTime.Instant.FromDateTimeUtc(DateTime.UtcNow),
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