using Shop.ViewModels.Client;
using Shop.ViewModels.Product;

namespace Shop.ViewModels.Order
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }

        public int Quantity { get; set; }

        public ShortClientViewModel ShortClientViewModel { get; set; }

        public ShortProductViewModel ShortProductViewModel { get; set; }
    }
}
