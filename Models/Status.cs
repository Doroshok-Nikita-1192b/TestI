using System.ComponentModel.DataAnnotations;

namespace TestI.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }
}
