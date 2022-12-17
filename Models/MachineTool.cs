using System;
using System.ComponentModel.DataAnnotations;

namespace TestI.Models
{
    public class MachineTool
    {
        [Key]
        public int MachineToolsId { get; set; }
        public string MachineToolsName { get; set; }
        public string Country { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Year { get; set; }
        public string MachineToolsStamp { get; set;  }
        public string MachineToolsTtype { get; set; }
    }
}
