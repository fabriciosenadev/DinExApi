using DinExApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DinExApi.Business.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> FindByIdAsync(int id, int userID);
        Task<object> AddAsync(Category category, int userId);
        Task<IEnumerable<Category>> FindAllAsync();
    }
}
