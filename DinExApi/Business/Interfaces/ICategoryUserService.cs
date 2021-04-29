using DinExApi.Domain.Models;
using DinExApi.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Business.Interfaces
{
    public interface ICategoryUserService
    {
        Task<ErrorCode> ComposeRelationCreationAsync(int categoryId, int userId);
        Task<ErrorCode> AddRelationAsync(CategoryUsers categoryUsers);
    }
}
