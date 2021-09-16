using System.ComponentModel.DataAnnotations;

namespace LHMS.SystemReports.Models
{
    public class Status
    {
        [Key]
        public int Id {get; set;}
        public string status { get; set; }
    }
}