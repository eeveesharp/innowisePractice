using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.BLL.Infrastructure;
using Shop.BLL.Interfaces;
using Shop.BLL.Models;
using Shop.DAL.EF;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;

namespace Shop.BLL.Services
{
    public class ProductServices : IProductServices<Product>
    {
        private readonly IProductRepository<ProductEntity> _productRepository;

        private readonly ApplicationContext _applicationContext;

        private readonly Validation _validation;

        public ProductServices(IProductRepository<ProductEntity> productRepository,
            ApplicationContext applicationContext)
        {
            _productRepository = productRepository;

            _applicationContext = applicationContext;

            _validation = new Validation(_applicationContext);
        }

        public Product Create(Product item)
        {
            var productEntity = ConvertProductToProductEntity(item);

            var resultProduct = _productRepository.Create(productEntity);

            return ConvertProductEntityToProduct(resultProduct);
        }

        private ProductEntity ConvertProductToProductEntity(Product item)
        {
            return new ProductEntity
            {
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity
            };
        }

        private Product ConvertProductEntityToProduct(ProductEntity item)
        {
            return new Product
            {
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity
            };
        }

        public void Delete(int id)
        {
            if (!_validation.IsCorrectId(id))
            {
                throw new ArgumentException();
            }

            var product = _applicationContext.Products.FirstOrDefault(p => p.Id == id);

            _applicationContext.Products.Remove(product);
        }

        public Product Get(int id)
        {
            var result = _applicationContext.Products.FirstOrDefault(c => c.Id == id);

            return ConvertProductEntityToProduct(result);
        }

        public IEnumerable<Product> GetAll()
        {
            var products = _productRepository.GetAll();

            var result = new List<Product>();

            foreach (var item in products)
            {
                result.Add(ConvertProductEntityToProduct(item));
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

            var productEntity = ConvertProductToProductEntity(item);

            var resultProduct = _productRepository.Update(productEntity);

            return ConvertProductEntityToProduct(resultProduct);
        }
    }
}
