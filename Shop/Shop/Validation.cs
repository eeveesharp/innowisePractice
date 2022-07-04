using Microsoft.EntityFrameworkCore;
using Shop.BD;

namespace Shop
{
    public class Validation
    {
        private readonly ApplicationContext _applicationContext;

        public Validation(ApplicationContext applicationContext)
        {
            this._applicationContext = applicationContext;
        }

        public bool IsCorrectQuantity(Product product)
        {
            return product.Quantity <= 1000 && product.Quantity > 0;
        }

        public  bool IsCorrectPrice(Product product)
        {
            return product.Price <= 1500
                   && product.Price > 0;
        }

        public  bool IsCorrectName(Product product)
        {
            return product.Name is not null;
        }

        public bool IsCorrectId(int id)
        {
            return _applicationContext.Products.AsNoTracking().FirstOrDefault(p => p.Id == id) is not null;
        }
    }
}
