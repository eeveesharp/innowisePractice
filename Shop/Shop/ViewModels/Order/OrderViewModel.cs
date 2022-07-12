namespace Shop.ViewModels.Order
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int ClientName { get; set; }

        public int ClientLastName { get; set; }

        public decimal TotalPrice { get; set; }

        public int Quantity { get; set; }
    }
}
