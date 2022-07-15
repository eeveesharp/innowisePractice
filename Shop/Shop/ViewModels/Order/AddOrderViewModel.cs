using Shop.ViewModels.Client;
using Shop.ViewModels.Product;

namespace Shop.ViewModels.Order
{
    public class AddOrderViewModel
    {
        public int ClientId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
