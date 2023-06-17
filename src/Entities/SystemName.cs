using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LHMS.SystemReports.Entities
{
    [Table("sr.system_names_lkp")]
    public class SystemName
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<SystemReport> SystemReports { get; set; }
    }
}