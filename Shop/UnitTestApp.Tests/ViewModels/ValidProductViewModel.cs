using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.BLL.Models;
using Shop.Validator;
using Shop.ViewModels.Product;

namespace UnitTestApp.Tests.ViewModels
{
    public static class ValidProductViewModel
    {
        public static IEnumerable<ProductViewModel> InitListProduct = new List<ProductViewModel>
            { new() { Id = 1, Name = "Test", Price = 100, Quantity = 3 } };

        public static ProductViewModel ProductViewModelValid = new() { Name = "testName", Price = 100, Quantity = 3 };
        public static AddProductViewModel AddProductViewModel = new() { Name = "testName", Price = 100, Quantity = 3 };
        public static ShortProductViewModel ProductViewModel = new() { Name = "testName", Price = 100, Quantity = 3 };
    }
}
