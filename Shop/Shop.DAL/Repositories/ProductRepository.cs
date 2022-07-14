using Shop.DAL.EF;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Repositories
{
    public class ProductRepository : GenericRepository<ProductEntity>, IGenericRepository<ProductEntity>
    {
        public ProductRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }
    }
}
