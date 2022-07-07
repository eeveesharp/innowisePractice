using AutoMapper;
using Shop.BLL.Models;
using Shop.DAL.Entities;

namespace Shop.BLL.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductEntity>().ReverseMap();

            CreateMap<Order, OrderEntity>().ReverseMap();
        }
    }
}
