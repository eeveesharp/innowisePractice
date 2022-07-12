namespace Shop.DAL.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public IEnumerable<OrderEntity>? Orders { get; set; }
    }
}
