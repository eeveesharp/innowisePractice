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
        private readonly IOrderServices _orderServices;

        private readonly IMapper _mapper;

        public OrderController(IOrderServices orderServices, IMapper mapper)
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

        [HttpPut("{id}")]
        public async Task<ShortOrderViewModel> Update(int id, AddOrderViewModel order, CancellationToken ct)
        {
            var orderResult = _mapper.Map<Order>(order);

            orderResult.Id = id;

            await _orderServices.Update(orderResult, ct);

            return _mapper.Map<ShortOrderViewModel>(orderResult);
        }

        [HttpPost]
        public async Task<ShortOrderViewModel> Create(AddOrderViewModel order, CancellationToken ct)
        {
            var orderResult = _mapper.Map<Order>(order);

            await _orderServices.Create(orderResult, ct);

            return _mapper.Map<ShortOrderViewModel>(orderResult);
        }

        [HttpGet("{id}")]
        public async Task<ShortOrderViewModel> GetById(int id, CancellationToken ct)
        {
            var order = await _orderServices.Get(id, ct);

            var test = _mapper.Map<ShortOrderViewModel>(order);

            return _mapper.Map<ShortOrderViewModel>(order);
        }
    }
}
