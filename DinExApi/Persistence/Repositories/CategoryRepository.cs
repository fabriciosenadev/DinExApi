using DinExApi.Domain.Models;
using DinExApi.Infrastructure.DB.Data;
using DinExApi.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DinExApiContext dinExApiContext) : base(dinExApiContext) { }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await dinExContext.Categories.FindAsync(id);
        }
    }
}