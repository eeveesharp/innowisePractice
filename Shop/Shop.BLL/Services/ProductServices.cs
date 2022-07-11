using AutoMapper;
using Shop.BLL.Interfaces;
using Shop.BLL.Models;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;


namespace Shop.BLL.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public ProductServices(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Product> Create(Product item, CancellationToken ct)
        {
            var resultProduct = await _productRepository.Create(_mapper.Map<ProductEntity>(item), ct);

            return _mapper.Map<Product>(resultProduct);
        }

        public async Task Delete(int id, CancellationToken ct)
        {
            var result = await _productRepository.Get(id, ct);

            await _productRepository.Delete(result,ct);
        }

        public async Task<Product> Get(int id, CancellationToken ct)
        {
            var result = await _productRepository.Get(id,ct);

            return _mapper.Map<Product>(result);
        }

        public async Task<IEnumerable<Product>> GetAll(CancellationToken ct)
        {
            return _mapper.Map<IEnumerable<Product>>(await _productRepository.GetAll(ct));
        }

        public async Task<Product> Update(Product item, CancellationToken ct)
        {
            var resultProduct = await _productRepository.Update(_mapper.Map<ProductEntity>(item), ct);

            return _mapper.Map<Product>(resultProduct);
        }
    }
}
