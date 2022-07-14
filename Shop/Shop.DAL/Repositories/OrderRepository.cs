using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Shop.DAL.EF;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Repositories
{
    public class OrderRepository : GenericRepository<OrderEntity>, IOrderRepository
    {
        public OrderRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public override async Task<OrderEntity?> Get(int id, CancellationToken ct)
        {
            var result = await DbSet.AsNoTracking().Include(c => c.Client).Include(c => c.Product).FirstOrDefaultAsync(c => c.Id == id, ct);

            return result;
        }

        public override async Task<IEnumerable<OrderEntity>> GetAll(CancellationToken ct)
        {
            var result = await DbSet.AsNoTracking().Include(c => c.Client).Include(c => c.Product).ToListAsync(ct);

            return result;
        }

        public override async Task<OrderEntity> Create(OrderEntity item, CancellationToken ct)
        {
            await DbSet.AddAsync(item, ct);

            await ApplicationContext.SaveChangesAsync(ct);

            return item;
        }
    }
}
