﻿using LHMS.SystemReports.Models.SystemReportStatus;

namespace LHMS.SystemReports.Models.SystemReport
{
    public class SystemReportResponse
    {
        public int Id { get; set; }

        public string ReporterId { get; set; }

        public string ReportName { get; set; }

        public NodaTime.Instant ReportDate { get; set; }

        public NodaTime.Instant CreatedDate { get; set; }

        public NodaTime.Instant? UpdatedDate { get; set; }

        public SystemReportStatusResponse SystemReportStatus { get; set; }

        public SystemNameResponse SystemName { get; set; }

        public string SystemUpdate { get; set; }

        public string PersonnelUpdates { get; set; }

        public string CreativeIdeasAndEvaluations { get; set; }

        public string BarriersOrChallenges { get; set; }

        public string HowCanIHelpYou { get; set; }

        public string PersonalGrowthAndDevelopment { get; set; }
    }
}