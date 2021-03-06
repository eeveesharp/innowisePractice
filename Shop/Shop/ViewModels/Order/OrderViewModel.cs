using Shop.ViewModels.Client;
using Shop.ViewModels.Product;

namespace Shop.ViewModels.Order
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }

        public int Quantity { get; set; }
#nullable disable
        public ShortClientViewModel Client { get; set; }
#nullable enable

#nullable disable
        public ShortProductViewModel Product { get; set; }
#nullable enable
    }
}
