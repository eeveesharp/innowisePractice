using AutoMapper;
using Shop.BLL.Interfaces;
using Shop.DAL.Interfaces;

namespace Shop.BLL.Services
{
    public class GenericServices<TModel, TEntity> : IGenericServices<TModel> where TModel : class where TEntity : class
    {
        protected readonly IGenericRepository<TEntity> Repository;

        protected readonly IMapper Mapper;

        public GenericServices(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public async Task<TModel> Create(TModel item, CancellationToken ct)
        {
            var resultOrder = await Repository.Create(Mapper.Map<TEntity>(item), ct);

            return Mapper.Map<TModel>(resultOrder);
        }

        public async Task Delete(int id, CancellationToken ct)
        {
            var result = await Repository.Get(id, ct);

            if (result != null)
            {
                await Repository.Delete(result, ct);
            }
        }

        public virtual async Task<TModel> Get(int id, CancellationToken ct)
        {
            var result = await Repository.Get(id, ct);

            return Mapper.Map<TModel>(result);
        }

        public async Task<IEnumerable<TModel>> GetAll(CancellationToken ct)
        {
            return Mapper.Map<IEnumerable<TModel>>(await Repository.GetAll(ct));
        }

        public async Task<TModel> Update(TModel item, CancellationToken ct)
        {
            var resultOrder = await Repository.Update(Mapper.Map<TEntity>(item), ct);

            return Mapper.Map<TModel>(resultOrder);
        }
    }
}
