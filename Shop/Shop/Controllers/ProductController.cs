using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Delete(int id)
        {
            Product product = _applicationContext.Products.FirstOrDefault(p => p.Id == id);

            _applicationContext.Products.Remove(product);

            _applicationContext.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public Product Update(Product product)
        {
            _applicationContext.Products.Update(product);

            _applicationContext.SaveChanges();

            var resultProduct = _applicationContext.Products.FirstOrDefault(p => p.Id == product.Id);

            return resultProduct;
        }

        [HttpPost]
        public Product Create(Product product)
        {
            _applicationContext.Products.Add(product);

            _applicationContext.SaveChanges();

            var resultProduct = _applicationContext.Products.FirstOrDefault(p => p.Name == product.Name);

            return resultProduct;
        }
    }
}