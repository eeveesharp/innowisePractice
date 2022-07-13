using Shop.ViewModels.Client;
using Shop.ViewModels.Product;

namespace Shop.ViewModels.Order
{
    public class ShortOrderViewModel
    {
        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public ShortClientViewModel? Client { get; set; }

        public ShortProductViewModel? Product { get; set; }
    }
}
