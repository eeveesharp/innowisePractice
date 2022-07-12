namespace Shop.DAL.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public ClientEntity? Client { get; set; }

        public int ProductId { get; set; }

        public ProductEntity? Product { get; set; }

        public decimal TotalPrice { get; set; }

        public int Quantity { get; set; }
    }
}
