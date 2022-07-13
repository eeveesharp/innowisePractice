using Shop.DAL.Entities;

namespace Bll.Test.Etities
{
    public class ValidOrderEntity
    {
        public static IEnumerable<OrderEntity> ListOrderEntity = new List<OrderEntity>
            { new() { Id = 1, ClientId = 1, ProductId = 1, Quantity = 3, TotalPrice = 100 } };

        public static OrderEntity OrderEntity = new() { Id = 1, ClientId = 1, ProductId = 1, Quantity = 3, TotalPrice = 100 };
    }
}
