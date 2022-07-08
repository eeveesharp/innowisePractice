using AutoMapper;
using Moq;
using Shop.BLL.Interfaces;
using Shop.BLL.Models;
using Shop.Controllers;
using Shop.ViewModels.Product;
using Shouldly;
using UnitTestApp.Tests.Models;
using UnitTestApp.Tests.ViewModels;
using Xunit;

namespace UnitTestApp.Tests.Controllers
{
    public class ProductControllerTest
    {
        private readonly Mock<IProductServices> _productServicesMock = new();

        private readonly Mock<IMapper> _mapper = new();

        [Fact]
        public async Task GetAll_WhenControllerHasData_ReturnsValidProductsList()
        {   //Arange
            var expectedProducts = ValidProduct.InitListProduct;
            var expectedProductViewModels = ValidProductViewModel.InitListProduct;

            _mapper.Setup(map => map.Map<IEnumerable<ProductViewModel>>(expectedProducts)).Returns(expectedProductViewModels);
            _productServicesMock.Setup(x => x.GetAll(default)).ReturnsAsync(expectedProducts);
            //Act
            var controller = new ProductController(_productServicesMock.Object, _mapper.Object);
            var result = await controller.GetAll(default);
            //Assert
            expectedProductViewModels.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task Add_WhenValidData_ReturnValidProduct()
        {   //Arange
            var addProduct = ValidProduct.ValidProductModel;
            var addProductViewMode = ValidProductViewModel.AddProductViewModel;
            var expectedAddProductViewModel = ValidProductViewModel.ProductViewModel;

            _mapper.Setup(map => map.Map<Product>(addProductViewMode)).Returns(addProduct);
            _mapper.Setup(map => map.Map<ShortProductViewModel>(addProduct)).Returns(expectedAddProductViewModel);
            _productServicesMock.Setup(c => c.Create(addProduct, default)).ReturnsAsync(addProduct);
            //Act
            var controller = new ProductController(_productServicesMock.Object, _mapper.Object);
            var result = await controller.Create(addProductViewMode, default);
            //Assert
            expectedAddProductViewModel.Name.ShouldBeEquivalentTo(result.Name);
            expectedAddProductViewModel.Price.ShouldBeEquivalentTo(result.Price);
            expectedAddProductViewModel.Quantity.ShouldBeEquivalentTo(result.Quantity);
        }

        [Fact]
        public async Task Update_WhenValidData_ReturnValidProduct()
        {//Arange
            var addProduct = ValidProduct.ValidProductModel;
            var addProductViewMode = ValidProductViewModel.AddProductViewModel;
            var expectedAddProductViewModel = ValidProductViewModel.ProductViewModel;

            _mapper.Setup(map => map.Map<Product>(addProductViewMode)).Returns(addProduct);
            _mapper.Setup(map => map.Map<ShortProductViewModel>(addProduct)).Returns(expectedAddProductViewModel);
            _productServicesMock.Setup(c => c.Update(addProduct, default)).ReturnsAsync(addProduct);
            //Act
            var controller = new ProductController(_productServicesMock.Object, _mapper.Object);
            var result = await controller.Update(default, addProductViewMode, default);
            //Assert
            expectedAddProductViewModel.Name.ShouldBeEquivalentTo(result.Name);
            expectedAddProductViewModel.Price.ShouldBeEquivalentTo(result.Price);
            expectedAddProductViewModel.Quantity.ShouldBeEquivalentTo(result.Quantity);
        }

        [Fact]
        public void Delete_WhenValidData_ReturnValidProduct()
        {   //Arange
            var deleteProduct = ValidProduct.ValidProductModel.Id;

            _mapper.Setup(map => map.Map<Product>(ValidProduct.ValidProductModel)).Returns(ValidProduct.ValidProductModel);
            _productServicesMock.Setup(c => c.Delete(deleteProduct, default));
            //Act
            var controller = new ProductController(_productServicesMock.Object, _mapper.Object);
            Action act = () => controller.Delete(deleteProduct, default);
            //Assert
            act.ShouldNotThrow();
        }
    }
}