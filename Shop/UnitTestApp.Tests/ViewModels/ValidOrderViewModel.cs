using Shop.ViewModels.Order;

namespace UnitTestApp.Tests.ViewModels
{
    public class ValidOrderViewModel
    {
        public static IEnumerable<OrderViewModel> ListOrder = new List<OrderViewModel>
            { new() { Id = 1, Quantity = 5, TotalPrice = 100,
                Client = new() { LastName = "test", Name = "test" },
                Product = new(){Quantity = 3, Name = "test",Price = 100}}
            };

        public static AddOrderViewModel AddOrderViewModel = new()
        {
            ClientId = 1,
            ProductId = 1,
            Quantity = 3,
        };

        public static ShortOrderViewModel ShortOrderViewModel = new()
        {
            TotalPrice = 100,
            Quantity = 3,
            Client = new() { LastName = "Test", Name = "Test" }
        };
    }
}
