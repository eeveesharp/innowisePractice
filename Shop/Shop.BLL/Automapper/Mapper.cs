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
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity
            };
        }

        private static Product ConvertProductEntityToProduct(ProductEntity item)
        {
            return new Product
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity
            };
        }

        //private static Product ConvertProductViewModelToProduct(ProductViewModel item)
        //{
        //    return new Product
        //    {
        //        Id = item.Id,
        //        Name = item.Name,
        //        Price = item.Price,
        //        Quantity = item.Quantity
        //    };
        //}

        //private static ProductViewModel ConvertProductToProductViewModel(Product item)
        //{
        //    return new ProductViewModel
        //    {
        //        Id = item.Id,
        //        Name = item.Name,
        //        Price = item.Price,
        //        Quantity = item.Quantity
        //    };
        //}
    }
}
