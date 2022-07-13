using Shop.BLL.Models;

namespace Bll.Test.Models
{
    public class ValidOrder
    {
        public static IEnumerable<Order> ListOrder = new List<Order>
            { new() { Id = 1, ClientId = 1, ProductId = 1, Quantity = 3,TotalPrice = 100} };

        public static Order ValidOrderModel = new() { Id = 1, ClientId = 1, ProductId = 1, Quantity = 3, TotalPrice = 100 };
    }
}
