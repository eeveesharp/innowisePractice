namespace Shop.ViewModels.Order
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public string? ClientName { get; set; }

        public string? ClientLastName { get; set; }

        public decimal TotalPrice { get; set; }

        public int Quantity { get; set; }
    }
}
