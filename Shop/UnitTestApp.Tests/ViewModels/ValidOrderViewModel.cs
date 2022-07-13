using Shop.ViewModels.Order;

namespace UnitTestApp.Tests.ViewModels
{
    public class ValidOrderViewModel
    {
        public static IEnumerable<OrderViewModel> ListOrder = new List<OrderViewModel>
            { new() { Id = 1, ClientLastName = "test", ClientName = "test", Quantity = 5, TotalPrice = 100 }};

        public static AddOrderViewModel AddOrderViewModel = new()
        {
            ClientId = 1,
            ProductId = 1,
            Quantity = 3,
            ClientViewModel = new() { Id = 1, LastName = "test", Name = "test" }
        };

        public static ShortOrderViewModel ShortOrderViewModel = new()
        {
            TotalPrice = 100,
            ClientLastName = "test",
            Quantity = 3,
            ClientName = "test",
            ProductName = "tv",
            ClientViewModel = new() { Id = 1, LastName = "test", Name = "test" }
        };
    }
}
