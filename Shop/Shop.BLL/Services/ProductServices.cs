using AutoMapper;
using Shop.BLL.Infrastructure;
using Shop.BLL.Interfaces;
using Shop.BLL.Models;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;


namespace Shop.BLL.Services
{
    public class ProductServices : IProductServices<Product>
    {
        private readonly IProductRepository<ProductEntity> _productRepository;

        private readonly IMapper _mapper;

        private readonly Validation _validation;

        public ProductServices(IProductRepository<ProductEntity> productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _validation = new Validation(_productRepository);
            _mapper = mapper;
        }

        public async Task<Product> Create(Product item, CancellationToken ct)
        {
            if (!_validation.IsCorrectName(item)
                || !_validation.IsCorrectPrice(item)
                || !_validation.IsCorrectQuantity(item))
            {
                throw new ArgumentException();
            }

            var resultProduct = await _productRepository.Create(_mapper.Map<ProductEntity>(item),ct);

            return _mapper.Map<Product>(resultProduct);
        }

        public async Task Delete(int id, CancellationToken ct)
        {
            if (!await _validation.IsCorrectId(id,ct))
            {
                throw new ArgumentException();
            }

            var result = await _productRepository.Get(id, ct);


            await _productRepository.Delete(result,ct);
        }

        public async Task<Product> Get(int id, CancellationToken ct)
        {
            if (!await _validation.IsCorrectId(id,ct))
            {
                throw new ArgumentException();
            }

            var result = await _productRepository.Get(id,ct);

            return _mapper.Map<Product>(result);
        }

        public async Task<IEnumerable<Product>> GetAll(CancellationToken ct)
        {
            return _mapper.Map<IEnumerable<Product>>(await _productRepository.GetAll(ct));
        }

        public async Task<Product> Update(Product item, CancellationToken ct)
        {
            if (!_validation.IsCorrectName(item)
                || !_validation.IsCorrectPrice(item)
                || !_validation.IsCorrectQuantity(item)
                || !await _validation.IsCorrectId(item.Id,ct))
            {
                throw new ArgumentException();
            }

            var resultProduct = await _productRepository.Update(_mapper.Map<ProductEntity>(item), ct);

            return _mapper.Map<Product>(resultProduct);
        }
    }
}
