using Microsoft.EntityFrameworkCore;
using Shop.DAL.Entities;

namespace Shop.DAL.EF
{
    public class ApplicationContext : DbContext
    {
#nullable disable
        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<OrderEntity> Orders { get; set; }

        public DbSet<ClientEntity> Clients { get; set; }
#nullable enable
        public ApplicationContext(DbContextOptions<ApplicationContext> contextOptions)
                : base(contextOptions)
        {
            Database.Migrate();
        }
    }
}
