using Microsoft.AspNetCore.Mvc;
using Shop.BD;

namespace Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public List<Product> Get()
        {
            List<Product> resultProduct = null;

            using (ApplicationContext db = new ApplicationContext())
            {
                Product phone = new Product { Name = "Phone", Price = 123, Quantity = 33 };
                Product TV = new Product { Name = "TV", Price = 432, Quantity = 12 };
                db.Products.Add(phone);
                db.Products.Add(TV);
                db.SaveChanges();
                resultProduct = db.Products.ToList();
            }

            return resultProduct; 
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Product phone = new Product { Name = "Phone", Price = 123, Quantity = 33 };
                db.Products.Add(phone);
                db.SaveChanges();
                db.Products.Remove(phone);
                db.SaveChanges();
            }

            return Ok();
        }

        [HttpPut]
        public IActionResult Update()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Product phone = new Product { Name = "Phone", Price = 123, Quantity = 33 };

                db.Products.Add(phone);
                db.SaveChanges();
                phone.Price = 1;
                db.Products.Update(phone);
                db.SaveChanges();
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult Create()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Product phone = new Product { Name = "Phone", Price = 123, Quantity = 33 };

                db.Products.Add(phone);
                db.SaveChanges();
            }

            return Ok();
        }
    }
}