using DinExApi.Infrastructure.DB.Data;
using DinExApi.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DinExApi.Persistence.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> DbSet;
        protected readonly DinExApiContext dinExContext;

        public Repository(DinExApiContext dinExContext)
        {
            this.dinExContext = dinExContext;
            DbSet = dinExContext.Set<T>();
        }

        public async virtual Task AddAsync(T entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async virtual Task DeleteAsync(T entity)
        {
            DbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await dinExContext.SaveChangesAsync();
        }

        public async virtual Task UpdateAsync(T entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }
    }
}
