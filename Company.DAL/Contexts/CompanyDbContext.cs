using Company.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.DAL.Contexts
{
    public class CompanyDbContext : DbContext
    {
       

        public DbSet<User> Users { get; set; }  
        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=CompanyProjectDb;Trusted_Connection=true;TrustServerCertificate=true");
        }
    }
}
