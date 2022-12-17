using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace TestI.Models
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<MachineTool> MachineTools { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
