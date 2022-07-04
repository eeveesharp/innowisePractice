using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.BD;

namespace Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        private readonly ApplicationContext _applicationContext;

        private readonly Validation _validation;

        public ProductController(ILogger<ProductController> logger,
            ApplicationContext applicationContext)
        {
            _logger = logger;
            _applicationContext = applicationContext;
            _validation = new Validation(applicationContext);
        }

        [HttpGet]
        public List<Product> GetAll()
        {
            var resultProduct = _applicationContext.Products.ToList();

            return resultProduct;
        }

        [HttpDelete("{id}")]
        public Product Delete(int id)
        {
            if (!_validation.IsCorrectId(id))
            {
                throw new ArgumentException();
            }

            var product = _applicationContext.Products.FirstOrDefault(p => p.Id == id);

            _applicationContext.Products.Remove(product);

            _applicationContext.SaveChanges();

            return product;
        }

        [HttpPut]
        public Product Update(Product product)
        {
            if (!_validation.IsCorrectName(product)
                || !_validation.IsCorrectPrice(product)
                || !_validation.IsCorrectQuantity(product)
                || !_validation.IsCorrectId(product.Id))
            {
                throw new ArgumentException();
            }

            _applicationContext.Products.Update(product);

            _applicationContext.SaveChanges();

            var resultProduct = _applicationContext.Products.FirstOrDefault(p => p.Id == product.Id);

            return resultProduct;
        }

        [HttpPost]
        public Product Create(Product product)
        {
            if (!_validation.IsCorrectName(product)
                || !_validation.IsCorrectPrice(product)
                || !_validation.IsCorrectQuantity(product))
            {
                throw new ArgumentException();
            }

            _applicationContext.Products.Add(product);

            _applicationContext.SaveChanges();

            var resultProduct = _applicationContext.Products.FirstOrDefault(p => p.Name == product.Name);

            return resultProduct;
        }
    }
}