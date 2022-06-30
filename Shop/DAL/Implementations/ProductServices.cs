using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DB;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Implementations
{
    internal class ProductServices : IProductServices
    {
        private readonly ApplicationContext _applicationContext;

        public ProductServices(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Create(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            Product product = _applicationContext.Products.FirstOrDefault(p => p.Id == id);

            _applicationContext.Products.Remove(product);

            _applicationContext.SaveChanges();
        }

        public void Update(int id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
