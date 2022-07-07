using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Shop.DAL.EF;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _applicationContext;

        public ProductRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<ProductEntity> Create(ProductEntity item, CancellationToken ct)
        {
            await _applicationContext.Products.AddAsync(item,ct);

            await _applicationContext.SaveChangesAsync(ct);

            return item;
        }

        public async Task Delete(ProductEntity product, CancellationToken ct)
        {
            _applicationContext.Products.Remove(product);

            await _applicationContext.SaveChangesAsync(ct);
        }

        public async Task<ProductEntity> Get(int id, CancellationToken ct)
        {
            return await _applicationContext.Products.AsNoTracking().FirstOrDefaultAsync(c =>c.Id == id, ct);
        }

        public async Task<IEnumerable<ProductEntity>> GetAll(CancellationToken ct)
        {
            return await _applicationContext.Products.AsNoTracking().ToListAsync(ct);
        }

        public async Task<ProductEntity> Update(ProductEntity item, CancellationToken ct)
        {
            _applicationContext.Products.Update(item);

            await _applicationContext.SaveChangesAsync(ct);

            return item;
        }
    }
}
