using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.BLL.Models;
using Shop.DAL.Entities;

namespace Shop.BLL.Automapper
{
    public static class Mapper
    {
        public static  ProductEntity ConvertProductToProductEntity(Product item)
        {
            return new ProductEntity
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity
            };
        }

        public static Product ConvertProductEntityToProduct(ProductEntity item)
        {
            return new Product
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity
            };
        }
    }
}
