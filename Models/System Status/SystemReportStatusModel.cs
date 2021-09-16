using System.ComponentModel.DataAnnotations.Schema;

namespace LHMS.SystemReports.Models {
    public class SystemReportStatus
    {

      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }
      public string Status {get; set; }
    }

}