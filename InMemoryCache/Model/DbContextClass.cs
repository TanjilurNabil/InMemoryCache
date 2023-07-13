using Microsoft.EntityFrameworkCore;

namespace InMemoryCache.Model
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options):base(options) 
        {

            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}

