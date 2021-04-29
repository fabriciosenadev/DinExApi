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
    public class UserService : BaseServices<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICategoryService _categoryService;
        private readonly ICategoryUserService _categoryUserService;

        public UserService(IUserRepository userRepository, ICategoryService categoryService, ICategoryUserService categoryUserService)
        {
            _userRepository = userRepository;
            _categoryService = categoryService;
            _categoryUserService = categoryUserService;
        }

        public async Task<object> ComposeUserCreation(User user)
        {
            ErrorCode hasError;

            if (Exists(user))
                return new { errorCode = ErrorCode.HasAlreadyExists };

            hasError = await AddAsync(user);
            if (hasError != ErrorCode.Empty)
                return new { errorCode = hasError };

            IEnumerable<Category> list = await FindAllStandardCategories();
            foreach (Category category in list)
            {
                hasError = await AddRelationCategoryToUser(category.Id, user.Id);
                if (hasError != ErrorCode.Empty)
                    return new { errorCode = hasError };
            }

            return user;
        }

        public async Task<ErrorCode> AddAsync(User user)
        {
            var isRegistered = await _userRepository.AddAsync(user);

            if (isRegistered != 1) return ErrorCode.ErrorToSave;

            return ErrorCode.Empty;
        }

        public async Task<User> FindByIdAsync(int userId) => await _userRepository.FindByIdAsync(userId); 

        public async Task<User> FindByEmailAsync(string email) => await _userRepository.FindUserByEmailAsync(email);

        public override bool Exists(User user)
        {
            var hasAlreadyExists = FindByEmailAsync(user.Email);

            if (hasAlreadyExists.Result == null) return false;

            return true;
        }

        private async Task<IEnumerable<Category>> FindAllStandardCategories() => await _categoryService.FindAllStandardAsync();

        private async Task<ErrorCode> AddRelationCategoryToUser(int categoryId, int userId) => await _categoryUserService.ComposeRelationCreationAsync(categoryId, userId);

    }
}
