using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Status
    {
        [Key]
        public int Id {get; set;}
        public string status { get; set; }
    }
}