using Shop.DAL.Entities;

namespace Bll.Test.Etities
{
    public class ValidOrderEntity
    {
        public static IEnumerable<OrderEntity> ListOrderEntity = new List<OrderEntity>
            { new() { Id = 1, ClientName = "bob",FinalPrice = 1000} };

        public static OrderEntity OrderEntity = new() { ClientName = "bob", FinalPrice = 1000 };
    }
}
