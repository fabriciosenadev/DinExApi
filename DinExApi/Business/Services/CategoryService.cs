using DinExApi.Application.Interfaces;
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

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> AddAsync(Category category, int userID)
        {
            DateTime dateNow = DateTime.Now;

            category.CreatedAt = dateNow;
            category.CreatedBy = userID;

            if (Validate(category))
                return await _categoryRepository.AddAsync(category);

            return 0;
        }

        public Task DeleteAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Category>> FindAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Category> FindByIdAsync(int id, int userID)
        {
            return await _categoryRepository.FindByIdAsync(id, userID);
        }

        public override bool Validate(Category entity)
        {
            var category = FindByIdAsync(entity.Id,1); //id user logado

            if (category != null) return false;

            return true;
        }
    }
}
