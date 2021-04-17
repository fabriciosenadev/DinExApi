using DinExApi.Application.Interfaces;
using DinExApi.Business.Interfaces;
using DinExApi.Business.Services;
using DinExApi.Domain.Models;
using DinExApi.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DinExApi.Application.Services
{
    public class CategoryService : BaseServices<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IUserService _userService;
        private readonly ICategoryUserService _categoryUserService;

        private CategoryUsers CategoryUsers;

        public CategoryService(ICategoryRepository categoryRepository, IUserService userService, ICategoryUserService categoryUserService, CategoryUsers categoryUsers)
        {
            _categoryRepository = categoryRepository;

            _userService = userService;
            _categoryUserService = categoryUserService;

            CategoryUsers = categoryUsers;
        }

        public async Task<object> AddAsync(Category category, int userId)
        {
            var errorCode = 1;
            var error = new { errorCode };

            DateTime dateNow = DateTime.Now;
            category.CreatedAt = dateNow;

            if (!Validate(category)) return error;

            await _categoryRepository.AddAsync(category);
            var result = AddRelationCategoryToUser(category, userId);

            //if (result.Count < 1) return error;

            return category;

        }

        public Task<IEnumerable<Category>> FindAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Category> FindByIdAsync(int categoryId)
        {
            return await _categoryRepository.FindByIdAsync(categoryId);
        }

        public Task<Category> FindByIdAsync(int id, int userID)
        {
            throw new NotImplementedException();
        }

        public override bool Validate(Category entity)
        {
            var category = FindByIdAsync(entity.Id);

            if (category != null) return false;

            return true;
        }

        public override bool Validate(Category entity, int userId)
        {
            throw new NotImplementedException();
        }

        private async Task<object> AddRelationCategoryToUser(Category category, int userId)
        {
            User user = await FindUserById(userId);

            CategoryUsers.Category = category;
            CategoryUsers.User = user;
            return await _categoryUserService.AddAsync(CategoryUsers);
        }

        private async Task<User> FindUserById(int userId)
        {
            return await _userService.FindByIdAsync(userId);
        }
    }
}
