using DinExApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Business.Interfaces
{
    public interface ICategoryUserService
    {
        Task<object> AddRelationAsync(int categoryId, int userId);
    }
}
