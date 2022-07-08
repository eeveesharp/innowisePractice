using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.BLL.Models;
using Shop.DAL.Entities;
using Shop.ViewModels.Product;

namespace UnitTestApp.Tests.Models
{
    public static class ValidProduct
    {
        public static IEnumerable<Product> InitListProduct = new List<Product>
            { new() { Id = 1, Name = "Test", Price = 100, Quantity = 3 } };

        public static Product ValidProductModel = new() { Name = "testName", Price = 100, Quantity = 3 };
    }
}
