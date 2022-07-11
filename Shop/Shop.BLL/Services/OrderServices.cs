using AutoMapper;
using Shop.BLL.Interfaces;
using Shop.BLL.Models;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;

namespace Shop.BLL.Services
{
    public class OrderServices : GenericServices<Order, OrderEntity>, IOrderServices
    {
        public OrderServices(IGenericRepository<OrderEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
