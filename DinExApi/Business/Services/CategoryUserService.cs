using DinExApi.Business.Interfaces;
using DinExApi.Domain.Models;
using DinExApi.Infrastructure.DB.Data;
using DinExApi.Infrastructure.Enums;
using DinExApi.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Business.Services
{
    public class CategoryUserService : BaseServices<CategoryUsers>, ICategoryUserService
    {
        private readonly DinExApiContext _context;
        private readonly ICategoryUserRepository _categoryUserRepository;
        //private ICategoryService _categoryService;
        //private IUserService _userService;

        public CategoryUserService(DinExApiContext context, ICategoryUserRepository categoryUserRepository)
        {
            _context = context;
            _categoryUserRepository = categoryUserRepository;
        }
        public async Task<ErrorCode> AddRelationAsync(int categoryId, int userId)
        {
            CategoryUsers categoryUsers = new CategoryUsers();

            categoryUsers.Category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
            categoryUsers.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            await _context.CategoryUsers.AddAsync(categoryUsers);
            var result = await _context.SaveChangesAsync();

            if (result != 1)
            {
                return ErrorCode.ErrorToSave;
            }

            return ErrorCode.Empty;
            

        }


        public override bool Validate(CategoryUsers entity)
        {
            throw new NotImplementedException();
        }

        public override bool Validate(CategoryUsers entity, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
