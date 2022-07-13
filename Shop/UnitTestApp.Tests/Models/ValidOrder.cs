using Shop.BLL.Models;

namespace UnitTestApp.Tests.Models
{
    public class ValidOrder
    {
        public static IEnumerable<Order> ListOrder = new List<Order>
            { new() {Id = 1,ProductId = 1,Quantity = 3,TotalPrice = 100,ClientId = 1 }};

        public static Order ValidOrderModel = new() { Id = 1, ProductId = 1, Quantity = 3, TotalPrice = 100, ClientId = 1 };
    }
}
