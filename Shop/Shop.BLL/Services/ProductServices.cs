using AutoMapper;
using Shop.BLL.Interfaces;
using Shop.BLL.Models;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;


namespace Shop.BLL.Services
{
    public class ProductServices : GenericServices<Product, ProductEntity>, IProductServices
    {
        public ProductServices(IGenericRepository<ProductEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
