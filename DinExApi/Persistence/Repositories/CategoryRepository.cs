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
    public class CategoryRepository : ICategoryRepository
    {
        public readonly DinExContext _context;
        public CategoryRepository(DinExContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var category = await FindByIdAsync(id);
                _context.Category.Remove(category);
            }
            catch (Exception e)
            {
                
            }
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await _context.Category.FindAsync(id);
        }

        public async Task<List<Category>> FindAllAsync()
        {
            return await _context.Category.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
