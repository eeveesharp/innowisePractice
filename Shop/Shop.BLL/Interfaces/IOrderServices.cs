using Shop.BLL.Models;

namespace Shop.BLL.Interfaces
{
    public interface IOrderServices
    {
        Task<IEnumerable<Order>> GetAll(CancellationToken ct);

        Task<Order> Get(int id, CancellationToken ct);

        Task<Order> Create(Order item, CancellationToken ct);

        Task<Order> Update(Order item, CancellationToken ct);

        Task Delete(int id, CancellationToken ct);
    }
}
