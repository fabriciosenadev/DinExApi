using DinExApi.Domain.Models;
using DinExApi.Infrastructure.DB.Data;
using DinExApi.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DinExApiContext _context;

        public UserRepository(DinExApiContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUser(int userId)
        {
            return await _context.Users.FindAsync(userId); ;
        }
    }
}
