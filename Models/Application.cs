using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestI.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }

        [ForeignKey("StatusId")]
        public Status Status { get; set; }

        [DisplayName("Status")]
        public int StatusId { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        [DisplayName("Client")]
        public int ClientId { get; set; }

        [ForeignKey("RepairId")]
        public Repair Repair { get; set; }

        [DisplayName("Repair")]
        public int RepairId { get; set; }

        [ForeignKey("MachineToolsId")]
        public MachineTool MachineTool { get; set; }

        [DisplayName("Machine Tool")]
        public int MachineToolsId { get; set; }
    }
}
