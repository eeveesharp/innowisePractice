using Shop.BLL.Models;

namespace UnitTestApp.Tests.Models
{
    public class ValidOrder
    {
        public static IEnumerable<Order> ListOrder = new List<Order>
            { new() {} };

        public static Order ValidOrderModel = new() { };
    }
}
