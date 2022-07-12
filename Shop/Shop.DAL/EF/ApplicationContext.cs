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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
           /* modelBuilder.Entity<OrderEntity>()
                .HasKey(c => new { c.ClientId, c.ProductId });

            modelBuilder.Entity<OrderEntity>()
                .HasOne(c => c.Client)
                .WithMany(c => c.Id)
                .HasForeignKey(c => c.ClientId);

            modelBuilder.Entity<OrderEntity>()
                .HasOne(c => c.Product)
                .WithMany(c => c.Orders)
                .HasForeignKey(c => c.ProductId);*/
        }
    }
}
