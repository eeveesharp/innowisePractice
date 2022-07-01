using Microsoft.AspNetCore.Mvc;
using Shop.BD;

namespace Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Product> GetAll()
        {
            List<Product> resultProduct;

            using (ApplicationContext db = new ApplicationContext())
            {
                resultProduct = db.Products.ToList();
            }

            return resultProduct; 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Product product = db.Products.FirstOrDefault(p => p.Id == id);

                db.Products.Remove(product);

                db.SaveChanges();
            }

            return Ok();
        }

        [HttpPut]
        public Product Update(Product product)
        {
            Product resultProduct;

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Products.Update(product);

                db.SaveChanges();

                resultProduct = db.Products.FirstOrDefault(p => p.Id == product.Id);
            }

            return resultProduct;
        }

        [HttpPost]
        public Product Create(Product product)
        {
            Product resultProduct;

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Products.Add(product);

                db.SaveChanges();

                resultProduct = db.Products.FirstOrDefault(p => p.Name == product.Name);
            }

            return resultProduct;
        }
    }
}