using DinExApi.Business.Interfaces;
using DinExApi.Domain.Models;
using DinExApi.Infrastructure.DB.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Business.Services
{
    public class CategoryUserService : ICategoryUserService
    {
        private readonly DinExApiContext _context;
        
        public CategoryUserService(DinExApiContext context)
        {
            _context = context;
        }
        public async Task<object> AddRelationAsync(int categoryId, int userId)
        {

            CategoryUsers categoryUsers = new CategoryUsers();
            categoryUsers.Category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
            categoryUsers.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            await _context.CategoryUsers.AddAsync(categoryUsers);
            var result = await _context.SaveChangesAsync();
            if (result != 1) return new { };

            return categoryUsers;
        }
    }
}
