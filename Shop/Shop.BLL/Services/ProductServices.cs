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

        public Product Create(Product item)
        {
            if (!_validation.IsCorrectName(item)
                || !_validation.IsCorrectPrice(item)
                || !_validation.IsCorrectQuantity(item))
            {
                throw new ArgumentException();
            }

            var resultProduct = _productRepository.Create(_mapper.Map<ProductEntity>(item));

            return _mapper.Map<Product>(resultProduct);
        }

        public void Delete(int id)
        {
            if (!_validation.IsCorrectId(id))
            {
                throw new ArgumentException();
            }

            _productRepository.Delete(id);
        }

        public Product Get(int id)
        {
            if (!_validation.IsCorrectId(id))
            {
                throw new ArgumentException();
            }

            var result = _productRepository.Get(id);

            return _mapper.Map<Product>(result);
        }

        public IEnumerable<Product> GetAll()
        {
            return _mapper.Map<IEnumerable<Product>>(_productRepository.GetAll());
        }

        public Product Update(Product item)
        {
            if (!_validation.IsCorrectName(item)
                || !_validation.IsCorrectPrice(item)
                || !_validation.IsCorrectQuantity(item)
                || !_validation.IsCorrectId(item.Id))
            {
                throw new ArgumentException();
            }

            var resultProduct = _productRepository.Update(_mapper.Map<ProductEntity>(item));

            return _mapper.Map<Product>(resultProduct);
        }
    }
}
