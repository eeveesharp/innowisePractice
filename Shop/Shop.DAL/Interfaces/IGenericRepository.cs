namespace Shop.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll(CancellationToken ct);

        Task<TEntity> Get(int id, CancellationToken ct);

        Task<TEntity> Create(TEntity item, CancellationToken ct);

        Task<TEntity> Update(TEntity item, CancellationToken ct);

        Task Delete(TEntity item, CancellationToken ct);
    }
}
