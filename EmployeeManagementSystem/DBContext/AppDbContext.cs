using EmployeeManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Users> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
