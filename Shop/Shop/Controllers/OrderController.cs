using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Interfaces;
using Shop.BLL.Models;
using Shop.ViewModels.Order;

namespace Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices<Order> _orderServices;

        private readonly IMapper _mapper;

        public OrderController(IOrderServices<Order> orderServices, IMapper mapper)
        {
            _orderServices = orderServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderViewModel>> GetAll(CancellationToken ct)
        {
            return _mapper.Map<List<OrderViewModel>>(await _orderServices.GetAll(ct));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken ct)
        {
            await _orderServices.Delete(id, ct);
        }

        [HttpPut]
        public async Task<OrderViewModel> Update(OrderViewModel order, CancellationToken ct)
        {
            var orderResult = _mapper.Map<Order>(order);

            await _orderServices.Update(orderResult, ct);

            return _mapper.Map<OrderViewModel>(orderResult);
        }

        [HttpPost]
        public async Task<OrderViewModel> Create(OrderViewModel order, CancellationToken ct)
        {
            var orderResult = _mapper.Map<Order>(order);

            await _orderServices.Create(orderResult, ct);

            return _mapper.Map<OrderViewModel>(orderResult);
        }
    }
}
