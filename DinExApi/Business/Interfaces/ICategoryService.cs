using DinExApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Business.Interfaces
{
    public interface ICategoryService
    {
        Task<object> AddAsync(Category category, int userId);
        Task<Category> FindByIdAsync(int categoryId);
    }
}
