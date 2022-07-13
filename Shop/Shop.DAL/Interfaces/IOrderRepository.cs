using Shop.DAL.Entities;

namespace Shop.DAL.Interfaces
{
    public interface IOrderRepository : IGenericRepository<OrderEntity>
    {
        new Task<OrderEntity?> Get(int id, CancellationToken ct);

        new Task<IEnumerable<OrderEntity>> GetAll(CancellationToken ct);
    }
}
