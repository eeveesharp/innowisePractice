using Microsoft.EntityFrameworkCore;
using Shop.ViewModels.Product;

namespace Shop.BD
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ProductViewModel> Products => Set<ProductViewModel>();

        public ApplicationContext(DbContextOptions<ApplicationContext> contextOptions)
        : base(contextOptions)
        {
           
        }
    }
}
