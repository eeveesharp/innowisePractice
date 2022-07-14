using Shop.BLL.Models;

namespace Shop.BLL.Interfaces
{
    public interface IOrderServices : IGenericServices<Order>
    {
        // Task<Order> Get(int id, CancellationToken ct);
    }
}
