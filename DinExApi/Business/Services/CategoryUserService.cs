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

        public async Task<ErrorCode> ComposeRelationCreationAsync(int categoryId, int userId)
        {
            CategoryUsers categoryUsers = new CategoryUsers();

            categoryUsers.Category = await FindCategoryByIdAsync(categoryId);
            categoryUsers.User = await FindUserByIdAsync(userId);

            if (Exists(categoryUsers))
                return ErrorCode.HasAlreadyExists;

            var hasError = await AddRelationAsync(categoryUsers);
            
            if (hasError != ErrorCode.Empty)
                return ErrorCode.ErrorToSave;

            return ErrorCode.Empty;
        }

        public async Task<ErrorCode> AddRelationAsync(CategoryUsers categoryUsers)
        {
            var result = await _categoryUserRepository.AddRelationAsync(categoryUsers);

            if (result != 1) 
                return ErrorCode.ErrorToSave;

            return ErrorCode.Empty;
        }


        public override bool Exists(CategoryUsers entity)
        {
            var hasAlreadyExists = _categoryUserRepository.FindRelationAsync(entity.Category.Id, entity.User.Id);
            if (hasAlreadyExists.Result == null) return false;

            return true;
        }

        private async Task<User> FindUserByIdAsync(int userId)
        {
            return await _categoryUserRepository.FindUserByIdAsync(userId);
        }

        private async Task<Category> FindCategoryByIdAsync(int categoryId)
        {
            return await _categoryUserRepository.FindCategoryByIdAsync(categoryId);
        }
    }
}
