using First_MVC_App.Models;
using Microsoft.EntityFrameworkCore;

namespace First_MVC_App.Data
{
    public class ITIContext :DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }

        public ITIContext(DbContextOptions options):base(options)
        {
        }
        public ITIContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=WIN-4433O6QKABI\\SQLEXPRESS01;Database=MVCST2;integrated security=true;trustservercertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
