using AutoMapper;
using Moq;
using Shop.BLL.Interfaces;
using Shop.BLL.Models;
using Shop.Controllers;
using Shop.ViewModels.Order;
using Shouldly;
using UnitTestApp.Tests.Models;
using UnitTestApp.Tests.ViewModels;
using Xunit;

namespace UnitTestApp.Tests.Controllers
{
    public class OrderControllerTest
    {
        private readonly Mock<IOrderServices> _orderServices = new();

        private readonly Mock<IMapper> _mapper = new();

        [Fact]
        public async Task GetAll_WhenControllerHasValidData_ReturnsOrderList()
        {
            //Arange
            var expectedOrders = ValidOrder.ListOrder;
            var expectedOrderViewModels = ValidOrderViewModel.ListOrder;

            _mapper.Setup(map => map.Map<IEnumerable<OrderViewModel>>(expectedOrders)).Returns(expectedOrderViewModels);
            _orderServices.Setup(x => x.GetAll(default)).ReturnsAsync(expectedOrders);
            //Act
            var controller = new OrderController(_orderServices.Object, _mapper.Object);
            var result = await controller.GetAll(default);
            //Assert
            expectedOrderViewModels.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task Add_WhenValidData_ReturnValidOrder()
        {   //Arange
            var addOrder = ValidOrder.ValidOrderModel;
            var addOrderViewModel = ValidOrderViewModel.AddOrderViewModel;
            var expectedAddOrderViewModel = ValidOrderViewModel.ShortOrderViewModel;

            _mapper.Setup(map => map.Map<Order>(addOrderViewModel)).Returns(addOrder);
            _mapper.Setup(map => map.Map<ShortOrderViewModel>(addOrder)).Returns(expectedAddOrderViewModel);
            _orderServices.Setup(c => c.Create(addOrder, default)).ReturnsAsync(addOrder);
            //Act
            var controller = new OrderController(_orderServices.Object, _mapper.Object);
            var result = await controller.Create(addOrderViewModel, default);
            //Assert
            expectedAddOrderViewModel.ClientName.ShouldBeEquivalentTo(result.ClientName);
            expectedAddOrderViewModel.FinalPrice.ShouldBeEquivalentTo(result.FinalPrice);
        }

        [Fact]
        public async Task Update_WhenValidData_ReturnValidOrder()
        { //Arange
            var addOrder = ValidOrder.ValidOrderModel;
            var addOrderViewModel = ValidOrderViewModel.AddOrderViewModel;
            var expectedAddOrderViewModel = ValidOrderViewModel.ShortOrderViewModel;

            _mapper.Setup(map => map.Map<Order>(addOrderViewModel)).Returns(addOrder);
            _mapper.Setup(map => map.Map<ShortOrderViewModel>(addOrder)).Returns(expectedAddOrderViewModel);
            _orderServices.Setup(c => c.Update(addOrder, default)).ReturnsAsync(addOrder);
            //Act
            var controller = new OrderController(_orderServices.Object, _mapper.Object);
            var result = await controller.Update(default, addOrderViewModel, default);
            //Assert
            expectedAddOrderViewModel.ClientName.ShouldBeEquivalentTo(result.ClientName);
            expectedAddOrderViewModel.FinalPrice.ShouldBeEquivalentTo(result.FinalPrice);
        }

        [Fact]
        public void Delete_WhenValidData_ReturnValidOrder()
        {   //Arange
            var deleteProduct = ValidOrder.ValidOrderModel.Id;

            _mapper.Setup(map => map.Map<Order>(ValidProduct.ValidProductModel)).Returns(ValidOrder.ValidOrderModel);
            _orderServices.Setup(c => c.Delete(deleteProduct, default));
            //Act
            var controller = new OrderController(_orderServices.Object, _mapper.Object);
            //Assert
            controller.Delete(deleteProduct, default).ShouldNotThrow();
        }
    }
}
