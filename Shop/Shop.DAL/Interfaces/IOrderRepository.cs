namespace Shop.DAL.Interfaces
{
    public interface IOrderRepository<OrderEntity>
    {
        Task<IEnumerable<OrderEntity>> GetAll(CancellationToken ct);

        Task<OrderEntity> Get(int id, CancellationToken ct);

        Task<OrderEntity> Create(OrderEntity item, CancellationToken ct);

        Task<OrderEntity> Update(OrderEntity item, CancellationToken ct);

        Task Delete(OrderEntity item, CancellationToken ct);
    }
}
