using Shop.BLL.Models;

namespace Bll.Test.Models
{
    public class ValidOrder
    {
        public static IEnumerable<Order> ListOrder = new List<Order>
            { new() { Id = 1, ClientId = 1, ProductId = 1, Quantity = 3, TotalPrice = 100,
                Client = new(){ Id = 1, LastName = "qqq", Name = "www" },
                Product = new(){ Id =1, Price = 100, Name = "tv", Quantity = 100 }
            } };

        public static Order ValidOrderModel = new() { Id = 1, ClientId = 1, ProductId = 1, Quantity = 3, TotalPrice = 100 };
    }
}
