namespace Shop.DAL.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }

        public string? ClientName { get; set; }

        public decimal FinalPrice { get; set; }
    }
}
