using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LHMS.SystemReports.Entities
{
    [Table("sr.system_reports")]
    public class SystemReport
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ReporterId { get; set; }

        public string ReportName { get; set; }

        public NodaTime.Instant ReportDate { get; set; }

        public NodaTime.Instant CreatedDate { get; set; }

        public NodaTime.Instant UpdatedDate { get; set; }

        public int SystemReportStatusId { get; set; }

        [ForeignKey("SystemReportStatusId")]
        public SystemReportStatus SystemReportStatus { get; set; }

        public int SystemNameId { get; set; }

        [ForeignKey("SystemNameId")]
        public SystemName SystemName { get; set; }

        public string SystemUpdate { get; set; }

        public string PersonnelUpdates { get; set; }

        public string CreativeIdeasAndEvaluations { get; set; }

        public string BarriersOrChallenges { get; set; }

        public string HowCanIHelpYou { get; set; }

        public string PersonalGrowthAndDevelopment { get; set; }

    }

}