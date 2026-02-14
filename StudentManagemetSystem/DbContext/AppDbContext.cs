
using Microsoft.EntityFrameworkCore;
using StudentManagemetSystem.Model;
namespace StudentManagemetSystem
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> students { get; set; }
        public DbSet<StudentFee> studentFee { get; set; }
    }
}
