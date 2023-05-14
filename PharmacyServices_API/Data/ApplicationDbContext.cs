using Microsoft.EntityFrameworkCore;
using PharmacyServices_API.Models;

namespace PharmacyServices_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<DrugList> DrugLists { get; set; }
        public DbSet<DrugType> DrugTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
