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
            try
            {
                await AddAsync(user);

                IEnumerable<Category> list = await FindAllStandardCategories();
                foreach (Category category in list)
                {
                    await AddRelationCategoryToUser(category.Id, user.Id);
                }

                return user;
            }
            catch (Exception e)
            {
                return e;
            }
        }

        public async Task AddAsync(User user)
        {
            var isRegistered = await _userRepository.AddAsync(user);

            if(isRegistered != 1)
            {
                throw new Exception($"msg:Erro para adicionar novo usuário. codigo:{ErrorCode.ErrorToSave}");
            }
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

        private async Task AddRelationCategoryToUser(int categoryId, int userId) { 
            var result = await _categoryUserService.ComposeRelationCreationAsync(categoryId, userId); 
            if(result != ErrorCode.Empty)
            {
                throw new Exception($"msg:Error ao criar relacionamento código:{result}");
            }
        }

    }
}
