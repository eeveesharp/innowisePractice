using Shop.BLL.Models;

namespace Bll.Test.Models
{
    public class ValidOrder
    {
        public static IEnumerable<Order> ListOrder = new List<Order>
            { new() { Id = 1, ClientName = "bob",FinalPrice = 1000} };

        public static Order ValidOrderModel = new() { ClientName = "bob", FinalPrice = 1000 };
    }
}
