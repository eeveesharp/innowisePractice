using Shop.ViewModels.Order;

namespace UnitTestApp.Tests.ViewModels
{
    public class ValidOrderViewModel
    {
        public static IEnumerable<OrderViewModel> ListOrder = new List<OrderViewModel>
            { new() { Id = 1, ClientName = "bob",FinalPrice = 1000}};

        public static AddOrderViewModel AddOrderViewModel = new() { ClientName = "bob", FinalPrice = 1000 };
        public static ShortOrderViewModel ShortOrderViewModel = new() { ClientName = "bob", FinalPrice = 2000 };
    }
}
