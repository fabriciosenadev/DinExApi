using DinExApi.Domain.Models;
using DinExApi.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Business.Interfaces
{
    public interface ICategoryService
    {
        Task<object> ComposeCategoryCreation(Category category, int userId);
        Task<ErrorCode> AddAsync(Category category);
        Task<Category> FindByIdAsync(int categoryId);
    }
}
