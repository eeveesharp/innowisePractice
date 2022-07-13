using Shop.ViewModels.Client;

namespace Shop.ViewModels.Order
{
    public class AddOrderViewModel
    {
        public int ClientId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public ClientViewModel ClientViewModel { get; set; }
    }
}
