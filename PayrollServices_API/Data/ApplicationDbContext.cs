using Microsoft.EntityFrameworkCore;
using PayrollServices_API.Models;

namespace PayrollServices_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Deduction> Deductions { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
