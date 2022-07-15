using Microsoft.EntityFrameworkCore;
using Shop.DAL.EF;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationContext applicationContext;

        protected readonly DbSet<TEntity> dbSet;

        public GenericRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
            dbSet = applicationContext.Set<TEntity>();
        }

        public virtual async Task<TEntity> Create(TEntity item, CancellationToken ct)
        {
            await dbSet.AddAsync(item, ct);

            await applicationContext.SaveChangesAsync(ct);

            return item;
        }

        public async Task Delete(TEntity item, CancellationToken ct)
        {
            dbSet.Remove(item);

            await applicationContext.SaveChangesAsync(ct);
        }

        public virtual async Task<TEntity?> Get(int id, CancellationToken ct)
        {
            var result = await dbSet.FindAsync(new object[] { id }, ct);

            return result;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(CancellationToken ct)
        {
            return await dbSet.AsNoTracking().ToListAsync(ct);
        }

        public async Task<TEntity> Update(TEntity item, CancellationToken ct)
        {
            applicationContext.Entry(item).State = EntityState.Modified;

            await applicationContext.SaveChangesAsync(ct);

            return item;
        }
    }
}
