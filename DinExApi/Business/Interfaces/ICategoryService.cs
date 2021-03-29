using DinExApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DinExApi.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> SearchAsync();
        Task AddAsync();
        Task DeleteAsync();
        Task<IEnumerable<Category>> FindAllAsync();
    }
}
