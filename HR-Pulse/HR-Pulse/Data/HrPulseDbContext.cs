using HR_Pulse.Models;
using Microsoft.EntityFrameworkCore;

namespace HR_Pulse.Data
{
    public class HrPulseDbContext : DbContext
    {
        public HrPulseDbContext(DbContextOptions<HrPulseDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
