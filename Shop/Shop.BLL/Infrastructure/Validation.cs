using Microsoft.EntityFrameworkCore;
using Shop.BLL.Models;
using Shop.DAL.EF;
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

        public bool IsCorrectId(int id)
        {
            return _productRepository.GetAll().FirstOrDefault(p => p.Id == id) is not null;
        }
    }
}
