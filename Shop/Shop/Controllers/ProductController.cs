using AutoMapper;
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
        private readonly IProductServices<Product> _productServices;

        private readonly IMapper _mapper;

        public ProductController(IProductServices<Product> productServices,IMapper mapper)
        {
            _productServices = productServices;

            _mapper = mapper;
        }

        [HttpGet]
        public List<ProductViewModel> GetAll()
        {
            return _mapper.Map<List<ProductViewModel>>(_productServices.GetAll());
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productServices.Delete(id);
        }

        [HttpPut]
        public ProductViewModel Update(ProductViewModel product)
        {
            var productResult = _mapper.Map<Product>(product);

            _productServices.Update(productResult);

            return _mapper.Map<ProductViewModel>(productResult);
        }

        [HttpPost]
        public ProductViewModel Create(ProductViewModel product)
        {
            var productResult = _mapper.Map<Product>(product);

            _productServices.Create(productResult);

            return _mapper.Map<ProductViewModel>(productResult);
        }
    }
}