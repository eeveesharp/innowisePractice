using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shop.BLL.Models;
using Shop.ViewModels.Product;

namespace Shop.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>();

            CreateMap<ProductViewModel, Product>();
        }
    }
}
