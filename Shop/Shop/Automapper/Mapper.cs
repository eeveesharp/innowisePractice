using Shop.BLL.Models;
using Shop.ViewModels.Product;

namespace Shop.Automapper
{
    public static class Mapper
    {
        public static Product ConvertProductViewModelToProduct(ProductViewModel item)
        {
            return new Product
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity
            };
        }

        public static ProductViewModel ConvertProductToProductViewModel(Product item)
        {
            return new ProductViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity
            };
        }
    }
}
