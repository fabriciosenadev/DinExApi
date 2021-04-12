using DinExApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Business.Interfaces
{
    public interface IUserService
    {
        Task<int> AddAsync(User user);
        Task UpdateAsync(int userId, string password);
        Task DeleteAsync(int userId);
        Task<User> FindByIdAsync(int userId);
    }
}
