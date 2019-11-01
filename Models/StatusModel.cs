using System.Collections.Generic;

namespace LHMSAPI.Models
{
    public class Status
    {
        public string status { get; set; }
        public ICollection<SystemReport> SystemReport {get; set;}
    }
}