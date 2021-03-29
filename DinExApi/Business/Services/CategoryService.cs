using DinExApi.Application.Interfaces;
using DinExApi.Domain.Models;
using DinExApi.Persistence.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DinExApi.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task AddAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Category>> FindAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Category>> SearchAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
