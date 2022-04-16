using System.ComponentModel.DataAnnotations;

namespace LHMS.SystemReports.Models
{
    public class StatusResponse
    {
        [Key]
        public int Id {get; set;}
        public string status { get; set; }
    }
}