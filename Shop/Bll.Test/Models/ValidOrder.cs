using Shop.BLL.Models;

namespace Bll.Test.Models
{
    public class ValidOrder
    {
        public static IEnumerable<Order> ListOrder = new List<Order>
            { new() { } };

        public static Order ValidOrderModel = new() { };
    }
}
