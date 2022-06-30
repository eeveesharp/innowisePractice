using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.DB
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Shop.db");
        }
    }
}
