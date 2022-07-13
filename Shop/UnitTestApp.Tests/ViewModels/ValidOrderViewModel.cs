using Shop.ViewModels.Order;

namespace UnitTestApp.Tests.ViewModels
{
    public class ValidOrderViewModel
    {
        public static IEnumerable<OrderViewModel> ListOrder = new List<OrderViewModel>
            { new() {}};

        public static AddOrderViewModel AddOrderViewModel = new() { };
        public static ShortOrderViewModel ShortOrderViewModel = new() { };
    }
}
