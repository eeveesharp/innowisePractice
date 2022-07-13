using Shop.ViewModels.Client;

namespace Shop.ViewModels.Order
{
    public class ShortOrderViewModel
    {
        public string ClientName { get; set; }

        public string ClientLastName { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public ClientViewModel ClientViewModel { get; set; }
    }
}
