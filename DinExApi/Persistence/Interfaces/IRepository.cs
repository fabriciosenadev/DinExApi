using System.Threading.Tasks;

namespace DinExApi.Persistence.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<int> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> SaveChanges();
    }
}
