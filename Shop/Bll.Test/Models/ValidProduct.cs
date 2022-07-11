using Shop.BLL.Models;

namespace Bll.Test.Models
{
    public static class ValidProduct
    {
        public static IEnumerable<Product> InitListProduct = new List<Product>
            { new() { Id = 1, Name = "Test", Price = 100, Quantity = 3 } };

        public static Product ValidProductModel = new() { Name = "testName", Price = 100, Quantity = 3 };
    }
}
