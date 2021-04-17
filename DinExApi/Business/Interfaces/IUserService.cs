using DinExApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Business.Interfaces
{
    public interface IUserService
    {
        Task<object> AddAsync(User user);
        Task<User> FindByIdAsync(int id);
    }
}
