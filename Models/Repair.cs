using System;
using System.ComponentModel.DataAnnotations;

namespace TestI.Models
{
    public class Repair
    {
        [Key]
        public int RepairId { get; set; }
        public string RepairName { get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RepairData { get; set; }
        public double RepairDuration { get; set; }
        public double HourlyCostWorker { get; set; }
        public double RepairCost { get; set; }
    }
}
