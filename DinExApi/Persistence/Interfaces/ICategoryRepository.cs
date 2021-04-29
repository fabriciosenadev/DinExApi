using DinExApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Persistence.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> FindByIdAsync(int categoryId);
        Task<Category> FindByNameAsync(string categoryName);
        Task<IEnumerable<Category>> FindAllStandardAsync();
    }
}
