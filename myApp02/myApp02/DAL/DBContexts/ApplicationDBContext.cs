using Microsoft.EntityFrameworkCore;
using myApp02.DAL.Entities;

namespace myApp02.DAL.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
