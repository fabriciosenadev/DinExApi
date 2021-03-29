using DinExApi.Domain.Models;
using System.Threading.Tasks;

namespace DinExApi.Persistence.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> SearchAsync(int id);
    }
}
