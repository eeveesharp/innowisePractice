using Microsoft.AspNetCore.Mvc;
using Shop.Automapper;
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
                products.Add(Mapper.ConvertProductToProductViewModel(product));
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
            var productResult = Mapper.ConvertProductViewModelToProduct(product);

            _productServices.Update(productResult);

            return Mapper.ConvertProductToProductViewModel(productResult);
        }

        [HttpPost]
        public ProductViewModel Create(ProductViewModel product)
        {
            var productResult = Mapper.ConvertProductViewModelToProduct(product);

            _productServices.Create(productResult);

            return Mapper.ConvertProductToProductViewModel(productResult);
        }
    }
}