using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Shop.DAL.EF;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Repositories
{
    public class ProductRepository : GenericRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(ApplicationContext applicationContext):base(applicationContext)
        {
           
        }
    }
}
