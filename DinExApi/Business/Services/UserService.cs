using DinExApi.Business.Interfaces;
using DinExApi.Domain.Models;
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

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> AddAsync(User user)
        {
            user.CreatedAt = DateTime.Now;
            if (Validate(user))
                return await _userRepository.AddAsync(user);

            return 0;
        }

        public async Task DeleteAsync(int userId)
        {
            User user = await FindByIdAsync(userId);
            await _userRepository.DeleteAsync(user);
        }

        public async Task UpdateAsync(int userId, string password)
        {
            User userToUpdate = await FindByIdAsync(userId);
            await _userRepository.UpdateAsync(userToUpdate);
        }

        public async Task<User> FindByIdAsync(int userId)
        {
            return await _userRepository.FindByIdAsync(userId);
        }
        
        private async Task<User> FindByEmailAsync(string email)
        {
            return await _userRepository.FindByEmailAsync(email);
        }

        public override bool Validate(User entity)
        {
            var user = FindByEmailAsync(entity.Email);
            if (user != null) return false;

            return true;
        }

        public override bool Validate(User entity, int Id)
        {
            throw new NotImplementedException();
        }

    }

}
