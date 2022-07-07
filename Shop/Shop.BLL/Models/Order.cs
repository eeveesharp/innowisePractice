namespace Shop.BLL.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string ClientName { get; set; }

        public decimal FinalPrice { get; set; }
    }
}
