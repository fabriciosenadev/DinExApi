using DinExApi.Domain.Models;
using DinExApi.Infrastructure.DB.Data;
using DinExApi.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Persistence.Repositories
{
    public class CategoryUserRepository : Repository<CategoryUsers>, ICategoryUserRepository
    {
        public CategoryUserRepository(DinExApiContext dinExContext) : base(dinExContext)
        {

        }

        public async Task<int> AddRelationAsync(CategoryUsers categoryUsers)
        {
            await dinExContext.CategoryUsers.AddAsync(categoryUsers);
            return await SaveChanges(); 
        }

        public async Task<Category> FindCategoryByIdAsync(int categoryId)
        {
            return await dinExContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
        }

        public async Task<CategoryUsers> FindRelationAsync(int categoryId, int userId)
        {
            return await dinExContext.CategoryUsers.FirstOrDefaultAsync(r => r.Category.Id == categoryId && r.User.Id == userId);
        }

        public async Task<User> FindUserByIdAsync(int userId)
        {
            return await dinExContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
