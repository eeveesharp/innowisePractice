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
        private readonly IGenericServices<Product> _productServices;

        private readonly IMapper _mapper;

        public ProductController(IGenericServices<Product> productServices, IMapper mapper)
        {
            _productServices = productServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductViewModel>> GetAll(CancellationToken ct)
        {
            return _mapper.Map<List<ProductViewModel>>(await _productServices.GetAll(ct));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken ct)
        {
            await _productServices.Delete(id, ct);
        }

        [HttpPut("{id}")]
        public async Task<ShortProductViewModel> Update(int id, AddProductViewModel product, CancellationToken ct)
        {
            var productResult = _mapper.Map<Product>(product);

            productResult.Id = id;

            await _productServices.Update(productResult, ct);

            return _mapper.Map<ShortProductViewModel>(productResult);
        }

        [HttpPost]
        public async Task<ShortProductViewModel> Create(AddProductViewModel product, CancellationToken ct)
        {
            var productResult = _mapper.Map<Product>(product);

            await _productServices.Create(productResult, ct);

            return _mapper.Map<ShortProductViewModel>(productResult);
        }
    }
}