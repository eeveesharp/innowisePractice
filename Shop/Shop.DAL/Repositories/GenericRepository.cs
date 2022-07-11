using Microsoft.EntityFrameworkCore;
using Shop.DAL.EF;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationContext _applicationContext;

        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            _dbSet = applicationContext.Set<TEntity>();
        }

        public async Task<TEntity> Create(TEntity item, CancellationToken ct)
        {
            await _dbSet.AddAsync(item, ct);

            await _applicationContext.SaveChangesAsync(ct);

            return item;
        }

        public async Task Delete(TEntity item, CancellationToken ct)
        {
            _dbSet.Remove(item);

            await _applicationContext.SaveChangesAsync(ct);
        }

        public async Task<TEntity> Get(int id, CancellationToken ct)
        {
            return await _dbSet.FindAsync(new object[] { id }, ct);
        }

        public async Task<IEnumerable<TEntity>> GetAll(CancellationToken ct)
        {
            return await _dbSet.AsNoTracking().ToListAsync(ct);
        }

        public async Task<TEntity> Update(TEntity item, CancellationToken ct)
        {
            _dbSet.Update(item);

            await _applicationContext.SaveChangesAsync(ct);

            return item;
        }
    }
}
