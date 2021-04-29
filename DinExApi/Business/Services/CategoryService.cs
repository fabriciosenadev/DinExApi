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
        private readonly ICategoryUserService _categoryUserService;

        public CategoryService(ICategoryRepository categoryRepository, ICategoryUserService categoryUserService)
        {
            _categoryRepository = categoryRepository;
            _categoryUserService = categoryUserService;
        }

        public async Task<object> ComposeCategoryCreation(Category category, int userId)
        {
            ErrorCode hasError;

            if (!Exists(category))
            {
                hasError = await AddAsync(category);
                if (hasError != ErrorCode.Empty) 
                    return new { errorCode = hasError };
            }
            else
            {
                var c = await FindByNameAsync(category.Name);
                category.Id = c.Id;
            }

            hasError = await AddRelationCategoryToUser(category.Id, userId);            
            if (hasError != ErrorCode.Empty) 
                return new { errorCode = hasError };

            return category;
        }

        public async Task<ErrorCode> AddAsync(Category category)
        {
            var isRegistered = await _categoryRepository.AddAsync(category);

            if (isRegistered != 1) return ErrorCode.ErrorToSave;

            return ErrorCode.Empty;
        }

        public async Task<Category> FindByIdAsync(int categoryId) => await _categoryRepository.FindByIdAsync(categoryId);

        private async Task<Category> FindByNameAsync(string categoryName) => await _categoryRepository.FindByNameAsync(categoryName);

        private async Task<ErrorCode> AddRelationCategoryToUser(int categoryId, int userId) => await _categoryUserService.ComposeRelationCreationAsync(categoryId, userId);

        public override bool Exists(Category category)
        {
            var hasAlreadyExists = FindByNameAsync(category.Name);

            if (hasAlreadyExists.Result == null) return false;

            return true;
        }
    }
}
