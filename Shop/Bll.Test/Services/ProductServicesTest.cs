using AutoMapper;
using Bll.Test.Etities;
using Bll.Test.Models;
using Moq;
using Shop.BLL.Models;
using Shop.BLL.Services;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using Shouldly;
using Xunit;

namespace Bll.Test.Services
{
    public class ProductServicesTest
    {
        private readonly Mock<IProductRepository> _productRepositoryMock = new();

        private readonly Mock<IMapper> _mapperMock = new();

        [Fact]
        public async Task GetAll_WhenProductServiceHasData_ReturnsProductEntityList()
        {
            _mapperMock.Setup(map => map.Map<IEnumerable<Product>>(ValidProductEntity.ProductEntityList)).Returns(ValidProduct.InitListProduct);
            _productRepositoryMock.Setup(s => s.GetAll(default)).ReturnsAsync(ValidProductEntity.ProductEntityList);

            var productServices = new ProductServices(_productRepositoryMock.Object, _mapperMock.Object);

            var result = await productServices.GetAll(default);

            ValidProduct.InitListProduct.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task Create_WhenProductServiceHasValidData_ReturnsProductEntity()
        {
            _mapperMock.Setup(map => map.Map<Product>(ValidProductEntity.ProductEntity)).Returns(ValidProduct.ValidProductModel);
            _mapperMock.Setup(map => map.Map<ProductEntity>(ValidProduct.ValidProductModel)).Returns(ValidProductEntity.ProductEntity);
            _productRepositoryMock.Setup(s => s.Create(ValidProductEntity.ProductEntity, default)).ReturnsAsync(ValidProductEntity.ProductEntity);

            var productServices = new ProductServices(_productRepositoryMock.Object, _mapperMock.Object);

            var result = await productServices.Create(ValidProduct.ValidProductModel, default);

            ValidProduct.ValidProductModel.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task Update_WhenProductServiceHasValidData_ReturnsProductEntity()
        {
            _mapperMock.Setup(map => map.Map<Product>(ValidProductEntity.ProductEntity)).Returns(ValidProduct.ValidProductModel);
            _mapperMock.Setup(map => map.Map<ProductEntity>(ValidProduct.ValidProductModel)).Returns(ValidProductEntity.ProductEntity);
            _productRepositoryMock.Setup(s => s.Update(ValidProductEntity.ProductEntity, default)).ReturnsAsync(ValidProductEntity.ProductEntity);

            var productServices = new ProductServices(_productRepositoryMock.Object, _mapperMock.Object);

            var result = await productServices.Update(ValidProduct.ValidProductModel, default);

            ValidProduct.ValidProductModel.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public void Delete_WhenValidData_ReturnValidProductEntity()
        {
            _mapperMock.Setup(map => map.Map<Product>(ValidProductEntity.ProductEntity)).Returns(ValidProduct.ValidProductModel);

            _productRepositoryMock.Setup(s => s.Delete(ValidProductEntity.ProductEntity, default));

            var productServices = new ProductServices(_productRepositoryMock.Object, _mapperMock.Object);

            productServices.Delete(ValidProduct.ValidProductModel.Id, default).ShouldNotThrow();
        }
    }
}