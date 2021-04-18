using DinExApi.Business.Interfaces;
using DinExApi.Domain.Models;
using DinExApi.Infrastructure.DB.Data;
using DinExApi.Infrastructure.Enums;
using DinExApi.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Business.Services
{
    public class CategoryService : BaseServices<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        //private readonly ICategoryUserService _categoryUserService;
        //private readonly IUserService _userService;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<object> AddAsync(Category category, int userId)
        {
            if (Validate(category))
                return new { errorCode = ErrorCode.HasAlreadyExists };

            var isRegistered = await _categoryRepository.AddAsync(category);
            
            if (isRegistered != 1)
                return new { errorCode = ErrorCode.ErrorToSave };

            return category;
        }

        public async Task<Category> FindByIdAsync(int categoryId)
        {
            return await _categoryRepository.FindByIdAsync(categoryId);
        }

        public override bool Validate(Category entity)
        {
            var hasAlreadyExists = FindByNameAsync(entity.Name);

            if (hasAlreadyExists.Result == null) return false;

            return true;
        }

        public override bool Validate(Category entity, int userId)
        {
            throw new NotImplementedException();
        }

        private async Task<Category> FindByNameAsync(string categoryName)
        {
            return await _categoryRepository.FindByNameAsync(categoryName);
        }

        //private async Task<object> AddRelationCategoryToUser(Category category, int userId)
        //{
        //    User user = await FindUserById(userId);

        //    //CategoryUsers.Category = category;
        //    //CategoryUsers.User = user;

        //    //return await _categoryUserService.AddAsync(CategoryUsers);
        //    return await _categoryUserService.AddRelationAsync(category, user);
        //}

        //private async Task<User> FindUserById(int userId)
        //{
        //    return await _userService.FindByIdAsync(userId);
        //}
    }
}
