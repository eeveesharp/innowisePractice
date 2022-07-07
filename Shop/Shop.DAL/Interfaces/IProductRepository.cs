using Shop.DAL.Entities;

namespace Shop.DAL.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetAll(CancellationToken ct);

        Task<ProductEntity> Get(int id, CancellationToken ct);

        Task<ProductEntity> Create(ProductEntity item, CancellationToken ct);

        Task<ProductEntity> Update(ProductEntity item, CancellationToken ct);

        Task Delete(ProductEntity item, CancellationToken ct);
    }
}
