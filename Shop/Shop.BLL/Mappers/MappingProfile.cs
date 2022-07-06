using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shop.BLL.Models;
using Shop.DAL.Entities;

namespace Shop.BLL.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductEntity>();

            CreateMap<ProductEntity, Product>();
        }
    }
}
