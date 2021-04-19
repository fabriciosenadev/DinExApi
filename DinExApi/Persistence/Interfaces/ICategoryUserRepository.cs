using DinExApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Persistence.Interfaces
{
    public interface ICategoryUserRepository: IRepository<CategoryUsers>
    {
        Task<int> AddRelationAsync(CategoryUsers categoryUsers);
        Task<User> FindUserByIdAsync(int userId);
        Task<Category> FindCategoryByIdAsync(int categoryId);
        Task<CategoryUsers> FindRelationAsync(int categoryId, int userId);
    }
}
