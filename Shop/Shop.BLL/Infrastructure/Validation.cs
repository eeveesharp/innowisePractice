using Shop.BLL.Interfaces;
using Shop.BLL.Models;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;

namespace Shop.BLL.Infrastructure
{
    public class Validation
    {
        private readonly IProductRepository<ProductEntity> _productRepository;

        public Validation(IProductRepository<ProductEntity> productRepository)
        {
            _productRepository = productRepository;
        }

        public bool IsCorrectQuantity(Product product)
        {
            return product.Quantity <= 1000
                   && product.Quantity > 0;
        }

        public bool IsCorrectPrice(Product product)
        {
            return product.Price <= 1500
                   && product.Price > 0;
        }

        public bool IsCorrectName(Product product)
        {
            return product.Name is not null;
        }

        public async Task<bool> IsCorrectId(int id, CancellationToken ct)
        {
            var result = await _productRepository.Get(id, ct);

            return result is not null;
        }
    }
}
