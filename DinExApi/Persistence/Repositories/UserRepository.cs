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
        public UserRepository(DinExApiContext context) : base(context) { }

        public async Task<User> FindByIdAsync(int userId)
        {
            return await dinExContext.Users.FindAsync(userId); ;
        }

        public async Task<User> FindUserByEmailAsync(string email)
        {
            return await dinExContext.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
