using AutoMapper;
using Shop.BLL.Interfaces;
using Shop.BLL.Models;
using Shop.DAL.EF;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;

namespace Shop.BLL.Services
{
    public class OrderServices : GenericServices<Order, OrderEntity>, IOrderServices
    {
        private readonly IOrderRepository _repository;

        private readonly IMapper _mapper;

        public OrderServices(IOrderRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override async Task<Order> Get(int id, CancellationToken ct)
        {
            var resultOrderEntity =  await _repository.Get(id, ct);

            var resultOrder = _mapper.Map<Order>(resultOrderEntity);

            return resultOrder;
        }
    }
}
