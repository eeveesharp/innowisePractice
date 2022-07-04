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

        public ProductController(ILogger<ProductController> logger,
            ApplicationContext applicationContext)
        {
            _logger = logger;
            _applicationContext = applicationContext;
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
            if (IsCorrectId(id) is null)
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
            if (!IsCorrectName(product)
                || !IsCorrectPrice(product)
                || !IsCorrectQuantity(product)
                || IsCorrectId(product.Id) is null)
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
            if (!IsCorrectName(product)
                || !IsCorrectPrice(product)
                || !IsCorrectQuantity(product))
            {
                throw new ArgumentException();
            }

            _applicationContext.Products.Add(product);

            _applicationContext.SaveChanges();

            var resultProduct = _applicationContext.Products.FirstOrDefault(p => p.Name == product.Name);

            return resultProduct;
        }

        private bool IsCorrectQuantity(Product product)
        {
            return product.Quantity <= 1000 && product.Quantity > 0;
        }

        private bool IsCorrectPrice(Product product)
        {
            return  product.Price <= 1500
                   && product.Price > 0;
        }

        private bool IsCorrectName(Product product)
        {
            return product.Name is not null;
        }

        private Product IsCorrectId(int id)
        {
            return  _applicationContext.Products.AsNoTracking().FirstOrDefault(p => p.Id == id);
        }
    }
}