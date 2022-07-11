namespace Shop.BLL.Interfaces
{
    public interface IGenericServices<TModel> where TModel : class
    {
        Task<IEnumerable<TModel>> GetAll(CancellationToken ct);

        Task<TModel> Get(int id, CancellationToken ct);

        Task<TModel> Create(TModel item, CancellationToken ct);

        Task<TModel> Update(TModel item, CancellationToken ct);

        Task Delete(int id, CancellationToken ct);
    }
}
