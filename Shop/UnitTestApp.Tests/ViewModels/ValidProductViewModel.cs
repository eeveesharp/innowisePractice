using Shop.ViewModels.Product;

namespace UnitTestApp.Tests.ViewModels
{
    public static class ValidProductViewModel
    {
        public static IEnumerable<ProductViewModel> InitListProduct = new List<ProductViewModel>
            { new() { Id = 1, Name = "Test", Price = 100, Quantity = 3 } };

        public static AddProductViewModel AddProductViewModel = new() { Name = "testName", Price = 100, Quantity = 3 };
        public static ShortProductViewModel ProductViewModel = new() { Name = "testName", Price = 100, Quantity = 3 };
    }
}
