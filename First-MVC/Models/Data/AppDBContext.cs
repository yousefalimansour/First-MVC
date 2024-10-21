using First_MVC.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace First_MVC.Models.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public AppDBContext()
            : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
            .UseSqlServer("Data Source=.;Initial Catalog=MVC02;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        }

    }
}
