using DinExApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Persistence.Interfaces
{
    interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task RemoveAsync(int id);
        Task<Category> FindByIdAsync(int id);
        Task<List<Category>> FindAllAsync();
    }
}
