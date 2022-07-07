namespace Shop.BLL.Interfaces
{
    public interface IProductServices<Product>
    {
        Task<IEnumerable<Product>> GetAll(CancellationToken ct);

        Task<Product> Get(int id, CancellationToken ct);

        Task<Product> Create(Product item, CancellationToken ct);

        Task<Product> Update(Product item, CancellationToken ct);

        Task Delete(int id, CancellationToken ct);
    }
}
