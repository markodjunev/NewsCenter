namespace NewsCenter.Data
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using NewsCenter.Data.Common.Repositories;

    public class EfRepository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public EfRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> All()
        {
            return this._dbSet;
        }

        public Task AddAsync(TEntity entity)
        {
            return this._dbSet.AddAsync(entity).AsTask();
        }

        public void Update(TEntity entity)
        {
            this._dbSet.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            this._dbSet.Remove(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return this._context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}
