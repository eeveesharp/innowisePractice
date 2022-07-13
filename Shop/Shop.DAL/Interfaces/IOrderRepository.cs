using Shop.DAL.Entities;

namespace Shop.DAL.Interfaces
{
    public interface IOrderRepository : IGenericRepository<OrderEntity>
    {
        Task<OrderEntity> Get(int id, CancellationToken ct);

        Task<IEnumerable<OrderEntity>> GetAll(CancellationToken ct);
    }
}
