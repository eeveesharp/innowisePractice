﻿using Shop.BLL.Infrastructure;
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

            _validation = new Validation(productRepository);
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

            _productRepository.Delete(id);
        }

        public Product Get(int id)
        {
            if (!_validation.IsCorrectId(id))
            {
                throw new ArgumentException();
            }

            var result = _productRepository.Get(id);

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
