using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Interfaces;
using Shop.BLL.Models;
using Shop.ViewModels.Product;

namespace Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices<BLL.Models.Product> _productServices;

        public ProductController(IProductServices<BLL.Models.Product> productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public List<ProductViewModel> GetAll()
        {
            var resultProduct = _productServices.GetAll();

            var products = new List<ProductViewModel>();

            foreach (var product in resultProduct)
            {
                products.Add(
                    new ProductViewModel
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Quantity = product.Quantity,
                        Price = product.Price
                    });
            }

            return products;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
             _productServices.Delete(id);
        }

        [HttpPut]
        public ProductViewModel Update(ProductViewModel product)
        {
            var productResult = ConvertProductViewModelToProduct(product);

            _productServices.Update(productResult);

            return ConvertProductToProductViewModel(productResult);
        }

        [HttpPost]
        public ProductViewModel Create(ProductViewModel product)
        {
            var productResult = ConvertProductViewModelToProduct(product);

            _productServices.Create(productResult);

            return ConvertProductToProductViewModel(productResult);
        }

        private Product ConvertProductViewModelToProduct(ProductViewModel item)
        {
            return new Product
            {
                Id =item.Id,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity
            };
        }

        private ProductViewModel ConvertProductToProductViewModel(Product item)
        {
            return new ProductViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity
            };
        }
    }
}