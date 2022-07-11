using AutoMapper;
using Shop.BLL.Interfaces;
using Shop.DAL.Interfaces;

namespace Shop.BLL.Services
{
    public class GenericServices<TModel, TEntity> : IGenericServices<TModel> where TModel : class where TEntity : class
    {
        protected readonly IGenericRepository<TEntity> _repository;

        protected readonly IMapper _mapper;

        public GenericServices(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TModel> Create(TModel item, CancellationToken ct)
        {
            var resultOrder = await _repository.Create(_mapper.Map<TEntity>(item), ct);

            return _mapper.Map<TModel>(resultOrder);
        }

        public async Task Delete(int id, CancellationToken ct)
        {
            var result = await _repository.Get(id, ct);

            await _repository.Delete(result, ct);
        }

        public async Task<TModel> Get(int id, CancellationToken ct)
        {
            var result = await _repository.Get(id, ct);

            return _mapper.Map<TModel>(result);
        }

        public async Task<IEnumerable<TModel>> GetAll(CancellationToken ct)
        {
            return _mapper.Map<IEnumerable<TModel>>(await _repository.GetAll(ct));
        }

        public async Task<TModel> Update(TModel item, CancellationToken ct)
        {
            var resultOrder = await _repository.Update(_mapper.Map<TEntity>(item), ct);

            return _mapper.Map<TModel>(resultOrder);
        }
    }
}
