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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DinExApiContext dinExContext) : base(dinExContext)
        {
        }

        public async Task<IEnumerable<Category>> FindAllStandardAsync()
        {
            return await dinExContext.Categories.Where(c => c.IsCustom == "no").ToListAsync();
        }

        public async Task<Category> FindByIdAsync(int categoryId)
        {
            return await dinExContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
        }

        public async Task<Category> FindByNameAsync(string categoryName)
        {
            return await dinExContext.Categories.FirstOrDefaultAsync(c => c.Name.Equals(categoryName));
        }
    }
}
