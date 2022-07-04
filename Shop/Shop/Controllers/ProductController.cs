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
        public IActionResult GetAll()
        {
            var resultProduct = _applicationContext.Products.ToList();

            return Ok(resultProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!IsCorrectId(id))
            {
                return BadRequest("Error");
            }

            var product = _applicationContext.Products.FirstOrDefault(p => p.Id == id);

            _applicationContext.Products.Remove(product);

            _applicationContext.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            if (!IsCorrectData(product))
            {
                return BadRequest("Error");
            }

            _applicationContext.Products.Update(product);

            _applicationContext.SaveChanges();

            var resultProduct = _applicationContext.Products.FirstOrDefault(p => p.Id == product.Id);

            return Ok(resultProduct);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!IsCorrectData(product))
            {
                return BadRequest("Error");
            }
            
            _applicationContext.Products.Add(product);

            _applicationContext.SaveChanges();

            var resultProduct = _applicationContext.Products.FirstOrDefault(p => p.Name == product.Name);

            return Ok(resultProduct);
        }

        private bool IsCorrectData(Product product)
        {
            return product.Quantity <= 1000 
                   && product.Quantity > 0 
                   && product.Price <= 1500 
                   && product.Price > 0;
        }

        private bool IsCorrectId(int id)
        {
            foreach (var product in _applicationContext.Products)
            {
                if (id == product.Id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}