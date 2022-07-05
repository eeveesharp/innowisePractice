using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Interfaces;
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
                        Name = product.Name,
                        Quantity = product.Quantity,
                        Price = product.Price
                    });
            }

            return products;
        }

        [HttpDelete("{id}")]
        public ProductViewModel Delete(int id)
        {
            _productServices.Delete(id);

            return null;
        }

        [HttpPut]
        public ProductViewModel Update(ProductViewModel product)
        {
           // _productServices.Update(product);

            return null;
        }

        [HttpPost]
        public ProductViewModel Create(ProductViewModel product)
        {
           // _productServices.Create(product);

            return null;
        }
    }
}