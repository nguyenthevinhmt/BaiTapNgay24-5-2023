using Microsoft.EntityFrameworkCore;
using ProductManager.Entities;

namespace ProductManager.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> products { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
