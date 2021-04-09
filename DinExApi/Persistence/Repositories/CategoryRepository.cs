using DinExApi.Domain.Models;
using DinExApi.Infrastructure.DB.Data;
using DinExApi.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DinExApi.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DinExApiContext dinExApiContext) : base(dinExApiContext) { }

        public async Task<Category> SearchAsync(int id)
        {
            return await dinExContext.Category
                .AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
