using AutoMapper;
using Shop.BLL.Interfaces;
using Shop.BLL.Models;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;

namespace Shop.BLL.Services
{
    public class OrderServices : GenericServices<Order, OrderEntity>, IOrderServices
    {
        private readonly IOrderRepository _repository;

        private readonly IGenericRepository<ProductEntity> _productRepository;

        private readonly IMapper _mapper;

        public OrderServices(IOrderRepository repository, IGenericRepository<ProductEntity> productRepository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public override async Task<Order> Create(Order item, CancellationToken ct)
        {
            var product = await _productRepository.Get(item.ProductId, ct);

            SetTotalPrice(item, product);

            SetQuantityForProduct(item, product, ct);

            var resultOrder = await _repository.Create(_mapper.Map<OrderEntity>(item), ct);

            var order = await _repository.Get(resultOrder.Id, ct);

            return _mapper.Map<Order>(order);
        }

        private void SetTotalPrice(Order item, ProductEntity? product)
        {
            if (product != null)
            {
                item.TotalPrice = product.Price * item.Quantity;
            }
        }

        private async void SetQuantityForProduct(Order item, ProductEntity? product, CancellationToken ct)
        {
            if (product != null)
            {
                product.Quantity -= item.Quantity;

                await _productRepository.Update(product, ct);
            }
        }
    }
}
