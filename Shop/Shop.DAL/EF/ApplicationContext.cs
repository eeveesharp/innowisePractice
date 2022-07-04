using Microsoft.EntityFrameworkCore;
using Shop.DAL.Entities;

namespace Shop.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ProductEntity> Products => Set<ProductEntity>();

        public ApplicationContext(DbContextOptions<ApplicationContext> contextOptions)
            : base(contextOptions)
        {

        }
    }
}
