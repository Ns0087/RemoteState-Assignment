using AssignmentXML.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssignmentXML.DAL.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<XmlTemplate> Templates { get; set; }
    }
}
