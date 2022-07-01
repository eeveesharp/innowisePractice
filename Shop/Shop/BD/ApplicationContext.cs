using Microsoft.EntityFrameworkCore;

namespace Shop.BD
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Shop;Trusted_Connection=True;");
        }
    }
}
