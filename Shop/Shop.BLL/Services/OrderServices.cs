using AutoMapper;
using Shop.BLL.Interfaces;
using Shop.BLL.Models;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;

namespace Shop.BLL.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IMapper _mapper;

        public OrderServices(IOrderRepository productRepository, IMapper mapper)
        {
            _orderRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Order> Create(Order item, CancellationToken ct)
        {
            var resultOrder = await _orderRepository.Create(_mapper.Map<OrderEntity>(item), ct);

            return _mapper.Map<Order>(resultOrder);
        }

        public async Task Delete(int id, CancellationToken ct)
        {
            var result = await _orderRepository.Get(id, ct);

            await _orderRepository.Delete(result, ct);
        }

        public async Task<Order> Get(int id, CancellationToken ct)
        {
            var result = await _orderRepository.Get(id, ct);

            return _mapper.Map<Order>(result);
        }

        public async Task<IEnumerable<Order>> GetAll(CancellationToken ct)
        {
            return _mapper.Map<IEnumerable<Order>>(await _orderRepository.GetAll(ct));
        }

        public async Task<Order> Update(Order item, CancellationToken ct)
        {
            var resultOrder = await _orderRepository.Update(_mapper.Map<OrderEntity>(item), ct);

            return _mapper.Map<Order>(resultOrder);
        }
    }
}
