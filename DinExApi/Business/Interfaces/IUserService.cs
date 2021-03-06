using DinExApi.Domain.Models;
using DinExApi.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Business.Interfaces
{
    public interface IUserService
    {
        Task<object> ComposeUserCreation(User user);
        Task AddAsync(User user);
        Task<User> FindByIdAsync(int id);
        Task<User> FindByEmailAsync(string email);
    }
}
