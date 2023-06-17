using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LHMS.SystemReports.Entities
{
    [Table("sr.system_report_status_lkp")]
    public class SystemReportStatus
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
    }

}