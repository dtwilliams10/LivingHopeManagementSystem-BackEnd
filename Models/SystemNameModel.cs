using System.Collections.Generic;

namespace LHMSAPI.Models
{
    public class SystemName
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SystemReport> SystemReports {get; set;}
    }
}