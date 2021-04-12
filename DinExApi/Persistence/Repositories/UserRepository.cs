using DinExApi.Domain.Models;
using DinExApi.Infrastructure.DB.Data;
using DinExApi.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DinExApiContext dinExApiContext) : base(dinExApiContext) { }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await dinExContext.User.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> FindByIdAsync(int userId)
        {
            return await dinExContext.User.FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
