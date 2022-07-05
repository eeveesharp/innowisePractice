using Shop.BLL.Automapper;
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

        private readonly Validation _validation;

        public ProductServices(IProductRepository<ProductEntity> productRepository)
        {
            _productRepository = productRepository;

            _validation = new Validation(_productRepository);
        }

        public Product Create(Product item)
        {
            if (!_validation.IsCorrectName(item)
                || !_validation.IsCorrectPrice(item)
                || !_validation.IsCorrectQuantity(item))
            {
                throw new ArgumentException();
            }

            var productEntity = Mapper.ConvertProductToProductEntity(item);

            var resultProduct = _productRepository.Create(productEntity);

            return Mapper.ConvertProductEntityToProduct(resultProduct);
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

            return Mapper.ConvertProductEntityToProduct(result);
        }

        public IEnumerable<Product> GetAll()
        {
            var products = _productRepository.GetAll();

            var result = new List<Product>();

            foreach (var item in products)
            {
                result.Add(Mapper.ConvertProductEntityToProduct(item));
            }

            return result;
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

            var productEntity = Mapper.ConvertProductToProductEntity(item);

            var resultProduct = _productRepository.Update(productEntity);

            return Mapper.ConvertProductEntityToProduct(resultProduct);
        }
    }
}
