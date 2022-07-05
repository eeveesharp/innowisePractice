using Microsoft.EntityFrameworkCore;
using Shop.DAL.EF;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Repositories
{
    public class ProductRepository : IProductRepository<ProductEntity>
    {
        private readonly ApplicationContext _applicationContext;

        public ProductRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public ProductEntity Create(ProductEntity item)
        {
            _applicationContext.Products.Add(item);

            _applicationContext.SaveChanges();

            return item;
        }

        public void Delete(int id)
        {
            _applicationContext.Products.Remove(_applicationContext.Products.Find(id));

            _applicationContext.SaveChanges();
        }

        public ProductEntity Get(int id)
        {
            return _applicationContext.Products.Find(id);
        }

        public IEnumerable<ProductEntity> GetAll()
        {
            return _applicationContext.Products.AsNoTracking();
        }

        public ProductEntity Update(ProductEntity item)
        {
            _applicationContext.Products.Update(item);

            _applicationContext.SaveChanges();

            return item;
        }
    }
}
