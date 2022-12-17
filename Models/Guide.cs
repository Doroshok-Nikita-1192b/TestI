using System.ComponentModel.DataAnnotations;

namespace TestI.Models
{
    public class Guide
    {
        [Key]
        public int GuideId { get; set; }
        public string GuideText { get; set; }
    }
}
