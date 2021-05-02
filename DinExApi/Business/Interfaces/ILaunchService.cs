using DinExApi.Domain.Models;
using DinExApi.Infrastructure.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DinExApi.Business.Interfaces
{
    public interface ILaunchService
    {
        Task<ErrorCode> AddAsync(Launch launch);
        Task UpdateAsync(Launch launch);
        Task<ErrorCode> DeleteAsync(int launchID);
        Task<Launch> FindByIdAsync(int launchID);
        Task<IEnumerable<Launch>> FindAllAsync();
    }
}
