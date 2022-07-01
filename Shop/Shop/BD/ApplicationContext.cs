using Microsoft.EntityFrameworkCore;

namespace Shop.BD
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();

        public ApplicationContext(DbContextOptions<ApplicationContext> contextOptions)
        : base(contextOptions)
        {
           
        }
    }
}
