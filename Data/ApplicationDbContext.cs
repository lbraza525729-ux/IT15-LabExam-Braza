using Microsoft.EntityFrameworkCore;
using IT15_LabExam_Braza.Models;

namespace IT15_LabExam_Braza.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
    }
}