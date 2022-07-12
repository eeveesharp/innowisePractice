using Shop.DAL.Entities;

namespace Bll.Test.Etities
{
    public class ValidOrderEntity
    {
        public static IEnumerable<OrderEntity> ListOrderEntity = new List<OrderEntity>
            { new() { } };

        public static OrderEntity OrderEntity = new() { };
    }
}
