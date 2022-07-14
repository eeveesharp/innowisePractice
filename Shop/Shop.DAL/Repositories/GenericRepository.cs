using Microsoft.EntityFrameworkCore;
using Shop.DAL.EF;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationContext ApplicationContext;

        protected readonly DbSet<TEntity> DbSet;

        public GenericRepository(ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
            DbSet = applicationContext.Set<TEntity>();
        }

        public async Task<TEntity> Create(TEntity item, CancellationToken ct)
        {
            await DbSet.AddAsync(item, ct);

            await ApplicationContext.SaveChangesAsync(ct);

            return item;
        }

        public async Task Delete(TEntity item, CancellationToken ct)
        {
            DbSet.Remove(item);

            await ApplicationContext.SaveChangesAsync(ct);
        }

        public virtual async Task<TEntity?> Get(int id, CancellationToken ct)
        {
            var result = await DbSet.FindAsync(new object[] { id }, ct);

            return result;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(CancellationToken ct)
        {
            return await DbSet.AsNoTracking().ToListAsync(ct);
        }

        public async Task<TEntity> Update(TEntity item, CancellationToken ct)
        {
            ApplicationContext.Entry(item).State = EntityState.Modified;

            await ApplicationContext.SaveChangesAsync(ct);

            return item;
        }
    }
}
