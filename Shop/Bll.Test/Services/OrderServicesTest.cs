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
    public class OrderServicesTest
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock = new();

        private readonly Mock<IMapper> _mapperMock = new();

        [Fact]
        public async Task GetAll_WhenOrderServiceHasData_ReturnsOrderEntityList()
        {
            _mapperMock.Setup(map => map.Map<IEnumerable<Order>>(ValidOrderEntity.ListOrderEntity)).Returns(ValidOrder.ListOrder);
            _orderRepositoryMock.Setup(s => s.GetAll(default)).ReturnsAsync(ValidOrderEntity.ListOrderEntity);

            var orderServices = new OrderServices(_orderRepositoryMock.Object, _mapperMock.Object);

            var result = await orderServices.GetAll(default);

            ValidOrder.ListOrder.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task Create_WhenOrderServiceHasValidData_ReturnsOrderEntity()
        {
            _mapperMock.Setup(map => map.Map<Order>(ValidOrderEntity.OrderEntity)).Returns(ValidOrder.ValidOrderModel);
            _mapperMock.Setup(map => map.Map<OrderEntity>(ValidOrder.ValidOrderModel)).Returns(ValidOrderEntity.OrderEntity);
            _orderRepositoryMock.Setup(s => s.Create(ValidOrderEntity.OrderEntity, default)).ReturnsAsync(ValidOrderEntity.OrderEntity);

            var OrderServices = new OrderServices(_orderRepositoryMock.Object, _mapperMock.Object);

            var result = await OrderServices.Create(ValidOrder.ValidOrderModel, default);

            ValidOrder.ValidOrderModel.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task Update_WhenOrderServiceHasValidData_ReturnsOrderEntity()
        {
            _mapperMock.Setup(map => map.Map<Order>(ValidOrderEntity.OrderEntity)).Returns(ValidOrder.ValidOrderModel);
            _mapperMock.Setup(map => map.Map<OrderEntity>(ValidOrder.ValidOrderModel)).Returns(ValidOrderEntity.OrderEntity);
            _orderRepositoryMock.Setup(s => s.Update(ValidOrderEntity.OrderEntity, default)).ReturnsAsync(ValidOrderEntity.OrderEntity);

            var orderServices = new OrderServices(_orderRepositoryMock.Object, _mapperMock.Object);

            var result = await orderServices.Update(ValidOrder.ValidOrderModel, default);

            ValidOrder.ValidOrderModel.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public void Delete_WhenValidData_ReturnValidOrderEntity()
        {
            _mapperMock.Setup(map => map.Map<Order>(ValidOrderEntity.OrderEntity)).Returns(ValidOrder.ValidOrderModel);
            _orderRepositoryMock.Setup(s => s.Delete(ValidOrderEntity.OrderEntity, default));

            var orderServices = new OrderServices(_orderRepositoryMock.Object, _mapperMock.Object);

            orderServices.Delete(ValidOrder.ValidOrderModel.Id, default).ShouldNotThrow();
        }
    }
}
