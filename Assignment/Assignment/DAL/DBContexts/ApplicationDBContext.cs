using Assignment.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment.DAL.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<HtmlTemplate> Templates { get; set; }

        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<HtmlTemplate>();
            modelBuilder.Entity<Document>().HasKey("id");
        }




    }
}
