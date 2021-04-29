using DinExApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Persistence.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByIdAsync(int userId);
        Task<User> FindUserByEmailAsync(string email);
    }
}
