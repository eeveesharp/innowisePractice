using AutoMapper;
using Shop.BLL.Models;
using Shop.ViewModels.Order;
using Shop.ViewModels.Product;

namespace Shop.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();

            CreateMap<Order, OrderViewModel>().ReverseMap();
        }
    }
}
