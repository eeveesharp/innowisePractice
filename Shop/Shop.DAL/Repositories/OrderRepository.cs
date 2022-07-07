using Microsoft.EntityFrameworkCore;
using Shop.DAL.EF;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _applicationContext;

        public OrderRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<OrderEntity> Create(OrderEntity item, CancellationToken ct)
        {
            await _applicationContext.Orders.AddAsync(item, ct);

            await _applicationContext.SaveChangesAsync(ct);

            return item;
        }

        public async Task Delete(OrderEntity product, CancellationToken ct)
        {
            _applicationContext.Orders.Remove(product);

            await _applicationContext.SaveChangesAsync(ct);
        }

        public async Task<OrderEntity> Get(int id, CancellationToken ct)
        {
            return await _applicationContext.Orders.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, ct);
        }

        public async Task<IEnumerable<OrderEntity>> GetAll(CancellationToken ct)
        {
            return await _applicationContext.Orders.AsNoTracking().ToListAsync(ct);
        }

        public async Task<OrderEntity> Update(OrderEntity item, CancellationToken ct)
        {
            _applicationContext.Orders.Update(item);

            await _applicationContext.SaveChangesAsync(ct);

            return item;
        }
    }
}
